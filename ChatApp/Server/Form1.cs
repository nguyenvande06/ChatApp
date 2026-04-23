using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Server
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            btnStart.Click += btnStart_Click;
            btnStop.Click += btnStop_Click;
        }
        private Socket? sckServer;
        private Dictionary<string, Socket> dictClients = new Dictionary<string, Socket>();
        // biến quản lý danh sách client trong nhóm
        // Key: RoomID, Value: Danh sách Username trong phòng đó
        private Dictionary<string, List<string>> dictRooms = new Dictionary<string, List<string>>();
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {

                // Code khởi động server ở đây

                // Khởi tạo scoket Server
                IPAddress ip = IPAddress.Parse(txtIP.Text);
                int port = int.Parse(txtPort.Text);
                sckServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint epServer = new IPEndPoint(ip, port);
                sckServer.Bind(epServer);
                sckServer.Listen(10);

                AppendLog("Server đang khởi động...", Color.Blue);
                lblStatus.Text = "● Server đang chạy";
                lblStatus.ForeColor = Color.Green;
                btnStart.Enabled = false; // Vô hiệu hóa nút Start sau khi chạy

                // TẠO THREAD CHÍNH: Chuyên đợi người kết nối vào
                Thread listenThread = new Thread(AcceptConnections);
                listenThread.IsBackground = true;
                listenThread.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void AcceptConnections()
        {
            while (sckServer != null)
            {
                try
                {
                    Socket clientSck = sckServer.Accept();
                    AppendLog($"Kết nối vật lý từ: {clientSck.RemoteEndPoint}", Color.Gray);

                    // Mỗi client mới PHẢI chạy trên Thread riêng để không chặn Accept
                    Thread t = new Thread(() => AuthenticateClient(clientSck));
                    t.IsBackground = true;
                    t.Start();
                }
                catch
                {
                    // Khi sckServer.Close() được gọi, vòng lặp sẽ kết thúc tại đây
                    break;
                }
            }
        }

        // kiểm tra danh tính client
        private void AuthenticateClient(Socket clientSck)
        {
            try
            {
                byte[] buffer = new byte[1024];
                int size = clientSck.Receive(buffer);
                if (size <= 0) return;
                bool isAuthenticated = false;

                string data = Encoding.UTF8.GetString(buffer, 0, size);

                if (data.StartsWith("CONNECT|"))
                {
                    string user = data.Split('|')[1];

                    lock (dictClients)
                    {
                        if (dictClients.ContainsKey(user))
                        {
                            clientSck.Send(Encoding.UTF8.GetBytes("ERROR|Tên này đã tồn tại!"));
                        }
                        else
                        {
                            dictClients.Add(user, clientSck);
                            clientSck.Send(Encoding.UTF8.GetBytes("CONNECTED_OK"));
                            isAuthenticated = true;
                        }
                    }
                    if (isAuthenticated)
                    {
                        AppendLog($"Đăng nhập thành công: {user}", Color.Green);
                        UpdateClientListUI(); // Cập nhật UI sau khi có client mới

                        // Sử dụng Task để xử lý bất đồng bộ mà không treo UI
                        Task.Run(async () => {
                            await Task.Delay(200); // Nghỉ 200ms để Client kịp chuẩn bị UI
                            BroadcastOnlineList();
                        });
                        ReceiveFromClient(user, clientSck);

                    }
                }
            }
            catch (Exception ex)
            {
                AppendLog("Lỗi xác thực: " + ex.Message, Color.Red);
                try { clientSck.Close(); } catch { }
            }
        }
        // Server gửi danh sách cho các client update UI
        private void BroadcastOnlineList()
        {
            string listData = "LIST";
            lock (dictClients)
            {
                foreach (var user in dictClients.Keys)
                {
                    listData += "|" + user;
                }

            }
            // message chỗ nào chạy để bình thường nè
            byte[] data = Encoding.UTF8.GetBytes(listData + "\n");
            lock (dictClients)
            {
                foreach (var client in dictClients.Values)
                {
                    try { client.Send(data); } catch { }
                }
            }

        }

        // nhận tin nhắn từ client thread

        private void ReceiveFromClient(string userName, Socket clientSck)
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[1024];
                    // Nếu Client tắt (bấm X), dòng này sẽ ném ra Exception
                    int size = clientSck.Receive(buffer);

                    if (size <= 0) break; // Client thoát một cách lịch sự

                    string msg = Encoding.UTF8.GetString(buffer, 0, size);
                    // Trong hàm ReceiveFromClient của Server
                    if (msg.StartsWith("PRIVATE|"))
                    {
                        string[] parts = msg.Split('|');
                        string receiver = parts[1];
                        string content = parts[2];

                        lock (dictClients)
                        {
                            if (dictClients.ContainsKey(receiver))
                            {
                                // Gửi cho người nhận theo cấu trúc chuẩn để Client dễ xử lý
                                byte[] privateData = Encoding.UTF8.GetBytes($"PRIVATE|{userName}|{content}\n");
                                dictClients[receiver].Send(privateData);
                            }
                        }
                    }
                    // 3. Sửa lại logic gửi GROUP| (Chỉ gửi cho người trong phòng)
                    else if (msg.StartsWith("GROUP|"))
                    {
                        string[] parts = msg.Split('|');
                        string roomId = parts[1];
                        string content = parts[2];
                        byte[] groupData = Encoding.UTF8.GetBytes($"GROUP|{roomId}|{userName}|{content}\n");
                        lock (dictRooms)
                        {
                            if (dictRooms.ContainsKey(roomId))
                            {
                                foreach (string member in dictRooms[roomId])
                                {
                                    if (member != userName)
                                    { // Không gửi ngược lại chính mình
                                        dictClients[member].Send(groupData);
                                    }
                                }
                            }
                        }
                        AppendLog($"GROUP|{roomId}|[{userName}]: {msg}", Color.Blue);
                    }
                    else if (msg.StartsWith("JOIN_ROOM|"))
                    {
                        string roomId = msg.Split('|')[1].Trim();
                        lock (dictRooms)
                        {
                            if (dictRooms.ContainsKey(roomId))
                            {
                                // Nếu chưa có tên trong danh sách phòng thì mới thêm vào
                                if (!dictRooms[roomId].Contains(userName))
                                {
                                    dictRooms[roomId].Add(userName);
                                }
                                clientSck.Send(Encoding.UTF8.GetBytes($"JOIN_OK|{roomId}\n"));
                                AppendLog($"{userName} đã vào phòng {roomId}", Color.Magenta);
                            }
                            else
                            {
                                // Trường hợp không tìm thấy phòng
                                clientSck.Send(Encoding.UTF8.GetBytes("ERROR|Không tìm thấy phòng này!\n"));
                            }
                        }
                    }
                    // Nhận tin tạo phòng mới từ Client
                    if (msg.StartsWith("CREATE_ROOM|"))
                    {
                        string roomId = msg.Split('|')[1].Trim();
                        lock (dictRooms)
                        {
                            if (dictRooms.ContainsKey(roomId))
                            {
                                clientSck.Send(Encoding.UTF8.GetBytes("ERROR|Phòng này đã tồn tại!\n"));
                            }
                            else
                            {
                                dictRooms.Add(roomId, new List<string>());
                                dictRooms[roomId].Add(userName);
                                clientSck.Send(Encoding.UTF8.GetBytes($"CREATE_OK|{roomId}\n"));
                                AppendLog($"Phòng {roomId} đã được tạo bởi {userName}", Color.Purple);
                            }
                        }
                    }
                }
            }
            catch
            {
                // Nhảy vào đây khi Client bấm X hoặc mất mạng
            }
            finally
            {
                // Luôn luôn dọn dẹp dù thoát bằng cách nào
                HandleClientDisconnect(userName, clientSck);
            }
        }
        private void HandleClientDisconnect(string userName, Socket clientSck)
        {
            bool isRemoved = false;

            // 1. Chỉ lock để xóa khỏi danh sách thật nhanh
            lock (dictClients)
            {
                if (dictClients.ContainsKey(userName))
                {
                    dictClients.Remove(userName);
                    isRemoved = true;
                }
            }

            // 2. Nếu thực sự xóa thành công thì mới cập nhật UI (Nằm ngoài lock)
            if (isRemoved)
            {
                this.BeginInvoke(new Action(() => {
                    AppendLog($"{userName} đã rời phòng.", Color.Red);

                    // CẬP NHẬT LẠI DANH SÁCH VÀ SỐ LƯỢNG ONLINE
                    UpdateClientListUI();
                    BroadcastOnlineList();
                }));
            }
            // Thêm vào HandleClientDisconnect trên Server
            lock (dictRooms)
            {
                foreach (var room in dictRooms.Values)
                {
                    room.Remove(userName);
                }
            }
            // 3. Giải phóng tài nguyên Socket
            try
            {
                if (clientSck != null && clientSck.Connected)
                {
                    clientSck.Shutdown(SocketShutdown.Both);
                    clientSck.Close();
                }
            }
            catch { /* Bỏ qua lỗi khi đóng socket đã chết */ }
        }
        private void AppendLog(string message, Color color)
        {
            if (rtbLog.InvokeRequired)
            {
                rtbLog.Invoke(new Action(() => AppendLog(message, color)));
                return;
            }
            // Ví dụ: Thêm log vào một RichTextBox tên là rtbLog
            rtbLog.SelectionStart = rtbLog.TextLength;
            rtbLog.SelectionLength = 0;
            rtbLog.SelectionColor = color;
            rtbLog.AppendText(message + Environment.NewLine);
            rtbLog.SelectionColor = rtbLog.ForeColor;
        }
        private void btnStop_Click(object? sender, EventArgs e)
        {
            if (sckServer != null)
            {
                sckServer.Close();
                sckServer = null;
                AppendLog("Server đã dừng.", Color.Red);
                lblStatus.Text = "● Server đã dừng";
                lblStatus.ForeColor = Color.Red;
                btnStart.Enabled = true;
            }
        }
        // Hàm cập nhật danh sách hiển thị và số lượng online
        private void UpdateClientListUI()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(UpdateClientListUI)); // Dùng BeginInvoke thay vì Invoke để tránh đợi nhau
                return;
            }

            lbClients.Items.Clear();
            List<string> currentUsers;

            // Chỉ lock trong thời gian cực ngắn để lấy dữ liệu
            lock (dictClients)
            {
                currentUsers = dictClients.Keys.ToList();
                lblClientCount.Text = $"{dictClients.Count} clients online";
            }

            // Cập nhật UI bằng danh sách phụ, không nằm trong lock
            foreach (var user in currentUsers)
            {
                lbClients.Items.Add(" 👤 " + user);
            }
        }
    }
}

