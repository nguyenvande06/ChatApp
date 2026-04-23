using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client;

namespace Client
{
    public partial class UC_Chat : UserControl
    {
        private Socket sckClient;
        // kiểm soát status của phòng ( in hay out)
        private bool isInGroup = false; // Biến flag kiểm soát trạng thái trong phòng
        private string joinedRoomId = ""; // lưu id group
        private string currentRoomOwner = "";
        public UC_Chat(Socket sck)
        {
            InitializeComponent();
            this.sckClient = sck;
            SetupWelcomeScreen(); // gọi hàm chào mừng 
            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();
            btnSend.Click += BtnSend_Click;
            btnGroupChat.Click += (s, e) => {
                // Nếu đã vào phòng (isInGroup = true), lấy lại tên phòng cũ từ joinedRoomId
                // Nếu chưa vào, dùng tên mặc định "Group" để hiện màn hình nhập mã
                string target = isInGroup ? "GROUP_" + joinedRoomId : "Group";
                SwitchChatContext(target, true, isInGroup);
            };
            txtMessage.KeyDown += TxtMessage_KeyDown;
            btnJoinRoom.Click += BtnJoinRoom_Click;
            btnLeaveRoom.Click += BtnLeaveRoom_Click;
            btnCreateRoom.Click += btnCreateRoom_Click;
            // kiểm tra 1 chút btnDeleteRoom.Click += btnDeleteRoom_Click;
            btnDeleteRoom.Click += (s, e) => {
                var confirm = MessageBox.Show("Bạn có chắc chắn muốn XÓA PHÒNG này không? Mọi người sẽ bị văng ra.",
                                             "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    string roomId = joinedRoomId; // Lấy ID phòng hiện tại
                    SendData("DELETE_ROOM|" + roomId);
                }
            };
        }
        private Panel pnlWelcome;
        private string currentChatTarget = ""; // để mặc định là trống ( nhằm hiển thị giao diện welcome)
                                                     // Mặc định là Group
                                                    // Key: Tên người gửi (hoặc "Group"), Value: Nội dung chat tương ứng
        private Dictionary<string, string> messageHistory = new Dictionary<string, string>();
        private void BtnSend_Click(object sender, EventArgs e)
        {
            // kiểm tra người dùng đã chọn ai để chat chưa
            if (string.IsNullOrEmpty(currentChatTarget))
            {
                MessageBox.Show("Vui lòng chọn một đối tượng để chat!");
                txtMessage.Clear(); // Xóa ô nhập liệu dù không gửi tin
                return;
            }
            string msgContent = txtMessage.Text.Trim(); // Lấy nội dung và xóa khoảng trắng thừa

            if (!string.IsNullOrEmpty(msgContent))
            {
                // Trong BtnSend_Click
                string data = (currentChatTarget.StartsWith("GROUP_"))
                    ? $"GROUP|{currentChatTarget.Replace("GROUP_", "")}|{msgContent}" // Thêm RoomID vào gói tin gửi đi
                    : $"PRIVATE|{currentChatTarget}|{msgContent}";
                if (sckClient != null && sckClient.Connected)
                {
                    try
                    {
                        // 1. Gửi dữ liệu đi
                        byte[] buffer = Encoding.UTF8.GetBytes(data);
                        sckClient.Send(buffer);

                        // 2. Hiển thị lên màn hình chat hiện tại
                        string displayMsg = "Tôi: " + msgContent + "\n";
                        rtbChat.AppendText(displayMsg);
                        rtbChat.ScrollToCaret(); // Tự động cuộn xuống dưới cùng

                        // 3. Lưu vào lịch sử (History) để chuyển tab không bị mất
                        if (!messageHistory.ContainsKey(currentChatTarget))
                            messageHistory[currentChatTarget] = "";
                        messageHistory[currentChatTarget] += displayMsg;

                        // 4. Xóa ô nhập liệu sau khi tất cả đã xong
                        txtMessage.Clear();
                    }
                    catch (Exception ex)
                    {
                        rtbChat.AppendText("Lỗi gửi tin: " + ex.Message + "\n");
                    }
                }
            }
        }


        private void SwitchChatContext(string targetName, bool isGroup, bool inRoom)
        {
            if (pnlWelcome != null) pnlWelcome.Visible = false;
            currentChatTarget = targetName;
            this.isInGroup = inRoom;

            if (isGroup)
            {
                if (!inRoom)
                {
                    btnDeleteRoom.Visible = false; // Ẩn nút delete khi chưa vào phòng cụ thể
                    pnlChatHeader.BackColor = Color.FromArgb(240, 245, 255);
                    // TRẠNG THÁI: CHƯA VÀO PHÒNG CỤ THỂ
                    pnlRoomManager.Visible = true;
                    pnlRoomManager.BringToFront();
                    rtbChat.Visible = false;
                    pnlInputArea.Visible = false;
                    btnLeaveRoom.Visible = false;
                    lblRoomInfo.Text = "💎 QUẢN LÝ PHÒNG CHAT";
                }
                else
                {
                    var mainForm = this.ParentForm as Form1;
                    if (mainForm != null && !string.IsNullOrEmpty(currentRoomOwner))
                    {
                        // Chỉ hiện nếu tên mình khớp với chủ phòng đã lưu
                        btnDeleteRoom.Visible = mainForm.MyUsername.Equals(currentRoomOwner, StringComparison.OrdinalIgnoreCase);
                    }
                    else
                    {
                        btnDeleteRoom.Visible = false;
                    }
                    pnlChatHeader.BackColor = Color.FromArgb(230, 240, 255);
                    // TRẠNG THÁI: ĐANG TRONG PHÒNG (Hoặc quay lại từ chat riêng)
                    pnlRoomManager.Visible = false;
                    rtbChat.Visible = true;
                    pnlInputArea.Visible = true;
                    btnLeaveRoom.Visible = true;

                    // Hiển thị mã phòng từ targetName (GROUP_101 -> 101)
                    string displayId = targetName.Replace("GROUP_", "");
                    lblRoomInfo.Text = "📣 PHÒNG CHAT: " + displayId;

                    rtbChat.Clear();
                    if (messageHistory.ContainsKey(targetName))
                    {
                        rtbChat.AppendText(messageHistory[targetName]);
                    }
                    HideNotificationIcon(targetName);
                }
            }
            else
            {
                btnDeleteRoom.Visible = false;
                pnlChatHeader.BackColor = Color.FromArgb(240, 255, 240);
                // TRẠNG THÁI: CHAT RIÊNG
                pnlRoomManager.Visible = false;
                rtbChat.Visible = true;
                pnlInputArea.Visible = true;
                btnLeaveRoom.Visible = false; // Chat riêng thì không có nút Leave phòng nhóm

                lblRoomInfo.Text = "👤 ĐANG CHAT VỚI: " + targetName;
                rtbChat.Clear();
                if (messageHistory.ContainsKey(targetName))
                    rtbChat.AppendText(messageHistory[targetName]);

                HideNotificationIcon(targetName);
                txtMessage.Focus();
            }
        }
        private void AddClientButton(string clientName)
        {
            Panel pnlItem = new Panel();
            pnlItem.Dock = DockStyle.Top;
            pnlItem.Height = 50;
            pnlItem.Name = "pnl_" + clientName;

            Button btn = new Button();
            btn.Name = "btn_" + clientName; // ✅ Đặt tên để tìm sau này
            btn.Text = "   👤   " + clientName;
            btn.Dock = DockStyle.Fill;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Cursor = Cursors.Hand;
            btn.Click += (s, e) => SwitchChatContext(clientName, false,isInGroup);

            Label lblNotify = new Label();
            lblNotify.BackColor = Color.LimeGreen;
            lblNotify.Size = new Size(10, 10);
            lblNotify.Location = new Point(190, 20);
            lblNotify.Name = "notify_" + clientName;
            lblNotify.Visible = false;

            btn.Controls.Add(lblNotify);
            pnlItem.Controls.Add(btn);
            pnlOnlineList.Controls.Add(pnlItem);
            pnlItem.BringToFront();
        }

        // Hàm phụ để tô màu nút đang chọn
        // cờ hiệu cho việc thông báo mật khẩu sai
        bool flag = false;
        private void Receive()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024];
                    int size = sckClient.Receive(buffer);
                    if (size <= 0) break;

                    // 1. Chuyển byte thành chuỗi
                    string rawData = Encoding.UTF8.GetString(buffer, 0, size);

                    // 2. Tách chuỗi theo ký tự \n để xử lý từng gói tin riêng biệt
                    string[] messages = rawData.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string msg in messages)
                    {
                        // Sử dụng BeginInvoke để cập nhật UI từ thread nhận tin
                        this.BeginInvoke((MethodInvoker)delegate {
                            if (this.IsDisposed || this.ParentForm == null) return;
                            // Trong hàm Receive (Client)

                            // 3. Phân loại gói tin
                            if (msg.StartsWith("LIST|"))
                            {
                                UpdateOnlineListUI(msg);
                            }
                            // Nhận tin Group để hiện icon đúng cho phòng chat nhóm
                            else if (msg.StartsWith("GROUP|"))
                            {
                                string[] parts = msg.Split('|');
                                if (parts.Length >= 4)
                                {
                                    string roomId = parts[1];
                                    string sender = parts[2];
                                    string content = parts[3];
                                    // Gọi hàm xử lý với RoomID cụ thể
                                    ProcessGroupMessage(roomId, sender, content);
                                }
                            }
                            else if (msg.StartsWith("PRIVATE|"))
                            {
                                string[] parts = msg.Split('|');
                                if (parts.Length >= 3)
                                {
                                    string sender = parts[1];
                                    string content = parts[2];
                                    ProcessIncomingMessage(sender, content, false);
                                }
                            }
                            else if (msg == "CONNECTED_OK")
                            {
                                // Xử lý khi đăng nhập thành công (nếu cần)
                                rtbChat.AppendText("Hệ thống: Kết nối thành công!\n");
                            }
                            else if (msg.StartsWith("CREATE_OK|") || msg.StartsWith("JOIN_OK|"))
                            {
                                string roomId = msg.Split('|')[1];
                                string ownerName = msg.Split('|')[2]; //  tên chủ phòng do server gửi
                                EnterRoomUI(roomId , ownerName); // Hàm này bạn đã có, dùng để hiện màn hình chat
                            }
                            else if (msg.StartsWith("ERROR|"))
                            {
                                string errorMsg = msg.Split('|')[1];
                                MessageBox.Show(errorMsg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            // delete room
                            else if (msg.StartsWith("ROOM_DELETED|"))
                            {
                                string roomId = msg.Split('|')[1];

                                // 1. Thông báo cho người dùng
                                MessageBox.Show($"Phòng chat {roomId} đã bị chủ phòng giải tán!", "Thông báo");

                                // 2. Reset trạng thái group của Client
                                this.isInGroup = false;
                                this.joinedRoomId = "";

                                // 3. Nếu Client đang ở chính cái phòng vừa bị xóa đó
                                if (currentChatTarget == "GROUP_" + roomId)
                                {
                                    // Ép quay về trang quản lý phòng ngay lập tức
                                    SwitchChatContext("Group", true, false);
                                }

                                // 4. Xóa lịch sử chat của phòng này (tùy chọn)
                                if (messageHistory.ContainsKey("GROUP_" + roomId))
                                    messageHistory.Remove("GROUP_" + roomId);
                            }
                            else if (msg.StartsWith("NEED_PASS|"))
                            {
                                string[] parts = msg.Split('|');
                                string roomId = parts[1];
                                string status = parts[2]; // Nhận "FIRST" hoặc "FAIL"

                                this.Invoke(new MethodInvoker(() => {
                                    // Nếu Server bảo FAIL (tức là vừa nhập xong mà sai) thì mới hiện thông báo
                                    if (status == "FAIL")
                                    {
                                        MessageBox.Show("Mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                    using (FrmCreateRoom frm = new FrmCreateRoom())
                                    {
                                        frm.SetJoinMode(roomId);
                                        if (frm.ShowDialog() == DialogResult.OK)
                                        {
                                            // Gửi lại mật khẩu người dùng vừa nhập trong Form
                                            SendData($"JOIN_ROOM|{roomId}|{frm.Password}");
                                        }
                                    }
                                }));
                            }
                            else
                            {
                                rtbChat.AppendText("Hệ thống: " + msg + "\n");
                            }

                        });
                    }
                }
                catch
                {
                    // Có thể ghi log lỗi ở đây trước khi break
                    break;
                }
            }
        }
        private void UpdateOnlineListUI(string data)
        {
            if (string.IsNullOrEmpty(data) || !data.StartsWith("LIST|")) return;

            this.Invoke((MethodInvoker)delegate {
                var mainForm = this.ParentForm as Form1;
                if (mainForm == null) return;

                string[] users = data.Split('|');

                // 1. Xóa danh sách cũ
                pnlOnlineList.Controls.Clear();

                // 2. Duyệt từ Index 1 đến hết
                for (int i = 1; i < users.Length; i++)
                {
                    string clientName = users[i].Trim();

                    // So sánh chính xác với Username của mình (đã lưu ở Form chính)
                    if (string.Equals(clientName, mainForm.MyUsername, StringComparison.OrdinalIgnoreCase))
                        continue;

                    AddClientButton(clientName);
                }
            });
        }

        // các hàm xử lý lưu lịch sử tin nhắn riêng và nhóm chung ( chỉnh swtich chat context để hiển thị đúng lịch sử khi click vào từng client hoặc nhóm )
        private void ProcessIncomingMessage(string sender, string content, bool isGroup)
        {
            string contextKey = isGroup ? "Group" : sender;

            // 1. Lưu tin nhắn vào bộ nhớ đệm
            if (!messageHistory.ContainsKey(contextKey))
                messageHistory[contextKey] = "";

            messageHistory[contextKey] += $"{sender}: {content}\n";

            // 2. Kiểm tra xem người dùng có đang xem cửa sổ này không
            if (currentChatTarget == contextKey)
            {
                // Nếu đang xem thì hiển thị ngay
                rtbChat.AppendText($"{sender}: {content}\n");
            }
            else
            {
                // Nếu KHÔNG xem thì hiện icon xanh thông báo
                ShowNotificationIcon(contextKey);
            }
        }

        private void ShowNotificationIcon(string targetName)
        {
            if (targetName == "Group")
            {
                lblGroupNotify.Visible = true;
            }
            else
            {
                // ✅ Tìm đúng: notify label nằm sâu bên trong (dùng Find với searchAllChildren = true)
                Control[] found = pnlOnlineList.Controls.Find("notify_" + targetName, true);
                if (found.Length > 0)
                    found[0].Visible = true;
            }
        }
        private void HideNotificationIcon(string targetName)
        {
            if (targetName == "Group" || targetName.StartsWith("GROUP_"))
            {
                lblGroupNotify.Visible = false;
                btnGroupChat.BackColor = Color.LightBlue;
            }
            else
            {
                // ✅ Nhất quán với ShowNotificationIcon
                Control[] found = pnlOnlineList.Controls.Find("notify_" + targetName, true);
                if (found.Length > 0)
                    found[0].Visible = false;

                // ✅ Reset màu nút về bình thường khi click vào
                Control[] btnFound = pnlOnlineList.Controls.Find("btn_" + targetName, true);
                if (btnFound.Length > 0)
                    btnFound[0].BackColor = SystemColors.Control;
            }
        }
        private void TxtMessage_KeyDown(object? sender, KeyEventArgs e)
        {
            // Kiểm tra xem phím vừa nhấn có phải là Enter không
            if (e.KeyCode == Keys.Enter)
            {
                // Ngăn tiếng "beep" mặc định của Windows khi nhấn Enter trong TextBox
                e.SuppressKeyPress = true;

                // Gọi lại logic của nút Gửi mà bạn đã viết
                BtnSend_Click(this, new EventArgs());
            }
        }
        // Welcome Panel (hiển thị khi chưa có tin nhắn nào)
        private void SetupWelcomeScreen()
        {
            // 1. Tạo Panel chào mừng
            pnlWelcome = new Panel();
            pnlWelcome.Dock = DockStyle.Fill;
            pnlWelcome.BackColor = Color.White; // Hoặc màu bạn thích

            // 2. Tạo nội dung chào mừng (Label)
            Label lblHello = new Label();
            lblHello.Text = "👋 Chào mừng bạn!\n\nHãy chọn một người dùng hoặc nhóm\nbên trái để bắt đầu trò chuyện.";
            lblHello.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblHello.TextAlign = ContentAlignment.MiddleCenter;
            lblHello.Dock = DockStyle.Fill;

            // 3. Thêm vào Panel
            pnlWelcome.Controls.Add(lblHello);

            // 4. Quan trọng: Thêm Panel này vào cùng chỗ với rtbChat
            // Giả sử rtbChat nằm trong một Panel cha nào đó, ta sẽ add vào đó
            if (rtbChat.Parent != null)
            {
                rtbChat.Parent.Controls.Add(pnlWelcome);
                pnlWelcome.BringToFront(); // Đưa lên trên cùng để che rtbChat và ô nhập liệu
            }
        }
        private void BtnJoinRoom_Click(object sender, EventArgs e)
        {
            string roomId = txtRoomID.Text.Trim();
            string password = "";
            if (string.IsNullOrEmpty(roomId))
            {
                MessageBox.Show("Vui lòng nhập mã phòng!");
                return;
            }

            // Gửi lệnh tham gia lên Server (Giao thức bạn tự định nghĩa)
            // Ví dụ: "JOIN_ROOM|roomId" , code phần logic gửi lên server để lưu lại danh sách Room
            string data = $"JOIN_ROOM|{roomId}|{password}";
            // dùng hàm SendData đã viết để gửi lên server 
            SendData(data);
            
        }

        private void EnterRoomUI(string roomId , string ownerName)
        {
            this.joinedRoomId = roomId;
            this.isInGroup = true; // Cập nhật trạng thái đã vào phòng
            this.currentRoomOwner = ownerName;
            currentChatTarget = "GROUP_" + roomId; // Đánh dấu đây là phòng chat nhóm cụ thể
            pnlRoomManager.Visible = false;
            rtbChat.Visible = true;
            pnlInputArea.Visible = true;
            var mainForm = this.ParentForm as Form1; // Lấy Username của mình từ Form chính
            if (mainForm != null && mainForm.MyUsername.Equals(ownerName, StringComparison.OrdinalIgnoreCase))
            {
                btnDeleteRoom.Visible = true; // Hiện nút nếu là chủ
            }
            else
            {
                btnDeleteRoom.Visible = false; // Ẩn nếu là thành viên
            }
            // HIỆN NÚT RỜI PHÒNG
            btnLeaveRoom.Visible = true;
            lblRoomInfo.Text = "📣 PHÒNG CHAT: " + roomId;
            rtbChat.Clear();
            // load tin cũ nếu có ( giả sử key lưu là "GROUP_roomId")
            if (messageHistory.ContainsKey(currentChatTarget))
                rtbChat.AppendText(messageHistory[currentChatTarget]);
        }
        private void BtnLeaveRoom_Click(object sender, EventArgs e)
        {
            if (currentChatTarget.StartsWith("GROUP_"))
            {
                string roomId = currentChatTarget.Replace("GROUP_", "");

                try
                {
                    string data = $"LEAVE_ROOM|{roomId}";
                    byte[] buffer = Encoding.UTF8.GetBytes(data);
                    sckClient.Send(buffer);
                }
                catch { }

                // RESET TRẠNG THÁI
                this.isInGroup = false;

                // QUAN TRỌNG: Truyền đúng chữ "Group" để SwitchChatContext hiểu là quay về màn hình Manager
                SwitchChatContext("Group", true, false);

                rtbChat.Clear();
                MessageBox.Show($"Đã rời phòng {roomId}");
            }
        }
        // xử lý chat nhóm với RoomID cụ thể 
        private void ProcessGroupMessage(string roomId, string sender, string content)
        {
            string contextKey = "GROUP_" + roomId;

            // Lưu vào lịch sử (Luôn làm để khi click vào phòng là có tin ngay)
            if (!messageHistory.ContainsKey(contextKey)) messageHistory[contextKey] = "";
            messageHistory[contextKey] += $"{sender}: {content}\n";

            // Trường hợp 1: Đang mở đúng phòng đó -> Hiện tin luôn, ẩn icon
            if (currentChatTarget == contextKey)
            {
                rtbChat.AppendText($"{sender}: {content}\n");
                lblGroupNotify.Visible = false;
            }
            // Trường hợp 2: Đang ở trang khác (Welcome, Chat riêng, hoặc Phòng khác) 
            // VÀ đã tham gia phòng này (isInGroup && joinedRoomId == roomId)
            else if (isInGroup && joinedRoomId == roomId)
            {
                lblGroupNotify.Visible = true; // Hiện icon chấm xanh ở nút "Chat Nhóm"
            }
            // Trường hợp 3: Chưa vào nhóm (Server đã chặn ở bước trên nên Client sẽ không nhận được tin này)
        }
        private void btnCreateRoom_Click(object sender, EventArgs e)
        {
            using (FrmCreateRoom frm = new FrmCreateRoom())
            {
                // Hiển thị form phụ dưới dạng Dialog (khóa form chính cho đến khi xong)
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string id = frm.RoomID;
                    string pass = frm.Password;

                    // Gửi dữ liệu lên Server
                    SendData($"CREATE_ROOM|{id}|{pass}");
                }
                
            }
        }
        private void SendData(string data)
        {
            try
            {
                if (sckClient != null && sckClient.Connected)
                {
                    // Thêm ký tự \n ở cuối để Server dễ dàng tách gói tin bằng Split('\n')
                    byte[] buffer = Encoding.UTF8.GetBytes(data + "\n");
                    sckClient.Send(buffer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi dữ liệu: " + ex.Message);
            }
        }
        




    }
}
