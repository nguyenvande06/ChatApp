namespace Client
{
    partial class UC_Chat
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlLeft = new Panel();
            pnlOnlineList = new Panel();
            lblOnlineHeader = new Label();
            btnGroupChat = new Button();
            lbClients = new ListBox();
            pnlCenter = new Panel();
            rtbChat = new RichTextBox();
            pnlInputArea = new Panel();
            txtMessage = new TextBox();
            btnSend = new Button();
            pnlChatHeader = new Panel();
            lblRoomInfo = new Label();
            pnlLeft.SuspendLayout();
            pnlOnlineList.SuspendLayout();
            pnlCenter.SuspendLayout();
            pnlInputArea.SuspendLayout();
            pnlChatHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(245, 246, 247);
            pnlLeft.Controls.Add(pnlOnlineList);
            pnlLeft.Controls.Add(lblOnlineHeader);
            pnlLeft.Controls.Add(btnGroupChat);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(220, 600);
            pnlLeft.TabIndex = 1;
            // 
            // pnlOnlineList
            // 
            pnlOnlineList.AutoScroll = true;
            pnlOnlineList.BackColor = Color.FromArgb(245, 246, 247);
            pnlOnlineList.Dock = DockStyle.Fill;
            pnlOnlineList.Location = new Point(0, 85);
            pnlOnlineList.Name = "pnlOnlineList";
            pnlOnlineList.Size = new Size(220, 515);
            pnlOnlineList.TabIndex = 1;

            // 
            // lblOnlineHeader
            // 
            lblOnlineHeader.Dock = DockStyle.Top;
            lblOnlineHeader.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblOnlineHeader.ForeColor = Color.Gray;
            lblOnlineHeader.Location = new Point(0, 50);
            lblOnlineHeader.Name = "lblOnlineHeader";
            lblOnlineHeader.Padding = new Padding(10, 0, 0, 5);
            lblOnlineHeader.Size = new Size(220, 35);
            lblOnlineHeader.TabIndex = 1;
            lblOnlineHeader.Text = "ONLINE CLIENTS";
            lblOnlineHeader.TextAlign = ContentAlignment.BottomLeft;
            // 
            // btnGroupChat
            // 
            btnGroupChat.BackColor = Color.FromArgb(230, 235, 240);
            btnGroupChat.Dock = DockStyle.Top;
            btnGroupChat.FlatAppearance.BorderSize = 0;
            btnGroupChat.FlatStyle = FlatStyle.Flat;
            btnGroupChat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGroupChat.Location = new Point(0, 0);
            btnGroupChat.Name = "btnGroupChat";
            btnGroupChat.Size = new Size(220, 50);
            btnGroupChat.TabIndex = 2;
            btnGroupChat.Text = " #  Chat Nhóm";
            btnGroupChat.TextAlign = ContentAlignment.MiddleLeft;
            btnGroupChat.UseVisualStyleBackColor = false;
            //
            // Cấu hình chấm xanh cho Group
            this.lblGroupNotify = new System.Windows.Forms.Label();
            this.lblGroupNotify.BackColor = Color.LimeGreen;
            this.lblGroupNotify.Location = new Point(190, 15); // Đặt ở góc phải của button
            this.lblGroupNotify.Name = "lblGroupNotify";
            this.lblGroupNotify.Size = new Size(12, 12); // Hình tròn nhỏ
            this.lblGroupNotify.Visible = false; // Mặc định ẩn
            this.btnGroupChat.Controls.Add(lblGroupNotify);


            // 
            // lbClients
            // 
            lbClients.BackColor = Color.FromArgb(245, 246, 247);
            lbClients.BorderStyle = BorderStyle.None;
            lbClients.Dock = DockStyle.Fill;
            lbClients.Location = new Point(0, 85);
            lbClients.Name = "lbClients";
            lbClients.Size = new Size(220, 515);
            lbClients.TabIndex = 0;
            // 
            // pnlCenter
            // 
            pnlCenter.Controls.Add(rtbChat);
            pnlCenter.Controls.Add(pnlInputArea);
            pnlCenter.Controls.Add(pnlChatHeader);
            pnlCenter.Dock = DockStyle.Fill;
            pnlCenter.Location = new Point(220, 0);
            pnlCenter.Name = "pnlCenter";
            pnlCenter.Size = new Size(680, 600);
            pnlCenter.TabIndex = 0;
            // 
            // rtbChat
            // 
            rtbChat.ReadOnly = true; // vô hiệu ghi đè nội dung
            rtbChat.TabStop = false; // bỏ focus khi click vào
            rtbChat.BorderStyle = BorderStyle.None;
            rtbChat.Dock = DockStyle.Fill;
            rtbChat.Location = new Point(0, 60);
            rtbChat.Name = "rtbChat";
            rtbChat.Size = new Size(680, 480);
            rtbChat.TabIndex = 0;
            rtbChat.Text = "";
            rtbChat.BackColor = Color.White;
            rtbChat.Font = new Font("Segoe UI", 12, FontStyle.Regular); // Chỉnh 12 hoặc 14 tùy bạn
            // 
            // pnlInputArea
            // 
            pnlInputArea.Controls.Add(txtMessage);
            pnlInputArea.Controls.Add(btnSend);
            pnlInputArea.Dock = DockStyle.Bottom;
            pnlInputArea.Location = new Point(0, 540);
            pnlInputArea.Name = "pnlInputArea";
            pnlInputArea.Padding = new Padding(10, 15, 10, 10);
            pnlInputArea.Size = new Size(680, 60);
            pnlInputArea.TabIndex = 1;
            // 
            // txtMessage
            // 
            txtMessage.Dock = DockStyle.Fill;
            txtMessage.Font = new Font("Segoe UI", 12F);
            txtMessage.Location = new Point(10, 15);
            txtMessage.Margin = new Padding(0, 0, 10, 0);
            txtMessage.Name = "txtMessage";
            txtMessage.Multiline = true;
            txtMessage.Size = new Size(590, 35);
            txtMessage.TabIndex = 0;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.FromArgb(0, 120, 215);
            btnSend.Dock = DockStyle.Right;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(600, 15);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(70, 35);
            btnSend.TabIndex = 1;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = false;
            // 
            // pnlChatHeader
            // 
            pnlChatHeader.BackColor = Color.White;
            pnlChatHeader.Controls.Add(lblRoomInfo);
            pnlChatHeader.Dock = DockStyle.Top;
            pnlChatHeader.Location = new Point(0, 0);
            pnlChatHeader.Name = "pnlChatHeader";
            pnlChatHeader.Size = new Size(680, 60);
            pnlChatHeader.TabIndex = 2;
            // 
            // lblRoomInfo
            // 
            lblRoomInfo.BringToFront();
            lblRoomInfo.Dock = DockStyle.Fill;
            lblRoomInfo.Location = new Point(0, 0);
            lblRoomInfo.Name = "lblRoomInfo";
            lblRoomInfo.Size = new Size(680, 60);
            /*
            lblRoomInfo.TabIndex = 0;
            lblRoomInfo.Text = "ChatApp - Version 1.0";
            lblRoomInfo.ForeColor = Color.FromArgb(44, 62, 80);*/
            // Ví dụ áp dụng cho lblVersion
            lblRoomInfo.ForeColor = Color.FromArgb(127, 140, 141); // Màu xám tinh tế
            lblRoomInfo.Font = new Font("Segoe UI", 11, FontStyle.Italic); // Chữ nhỏ và in nghiêng
            lblRoomInfo.Text = "ChatApp - Version 1.0";
            lblRoomInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UC_Chat
            // 
            Controls.Add(pnlCenter);
            Controls.Add(pnlLeft);
            Name = "UC_Chat";
            Size = new Size(900, 600);
            pnlLeft.ResumeLayout(false);
            pnlOnlineList.ResumeLayout(false);
            pnlCenter.ResumeLayout(false);
            pnlInputArea.ResumeLayout(false);
            pnlInputArea.PerformLayout();
            pnlChatHeader.ResumeLayout(false);
            ResumeLayout(false);
            //
            // Thêm lblMyName vào pnlChatHeader
            this.lblMyName = new System.Windows.Forms.Label();
            // pnlChatHeader
            pnlChatHeader.BackColor = Color.White;
            pnlChatHeader.Controls.Add(lblMyName); // Thêm lblMyName vào panel tiêu đề
            pnlChatHeader.Controls.Add(lblRoomInfo);
            pnlChatHeader.Dock = DockStyle.Top;
            // ...

            // Cấu hình cho lblMyName (vị trí góc trên bên phải)
            this.lblMyName.AutoSize = true;
            this.lblMyName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblMyName.ForeColor = Color.FromArgb(0, 120, 215);
            this.lblMyName.Location = new Point(530, 20); // Bạn có thể điều chỉnh tọa độ này
            this.lblMyName.Name = "lblMyName";
            this.lblMyName.Size = new Size(100, 20);
            this.lblMyName.Text = "👤 Đang kết nối...";
            this.lblMyName.Anchor = AnchorStyles.Top | AnchorStyles.Right; // Để nó luôn nằm bên phải khi phóng to
            //
            // --- Khởi tạo pnlRoomManager ---
            this.pnlRoomManager = new System.Windows.Forms.Panel();
            this.txtRoomID = new System.Windows.Forms.TextBox();
            this.btnJoinRoom = new System.Windows.Forms.Button();
            this.btnCreateRoom = new System.Windows.Forms.Button(); // Khởi tạo nút mới
            this.lblRoomManagerTitle = new System.Windows.Forms.Label();

            this.pnlRoomManager.BackColor = Color.White;
            this.pnlRoomManager.Dock = DockStyle.Fill;
            this.pnlRoomManager.Visible = false; // Mặc định ẩn

            // Tiêu đề
            this.lblRoomManagerTitle.Text = "NHẬP MÃ PHÒNG ĐỂ THAM GIA";
            this.lblRoomManagerTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.lblRoomManagerTitle.Location = new Point(0, 100);
            this.lblRoomManagerTitle.Size = new Size(680, 40);
            this.lblRoomManagerTitle.TextAlign = ContentAlignment.MiddleCenter;

            // Ô nhập mã phòng
            this.txtRoomID.Size = new Size(200, 30);
            this.txtRoomID.Location = new Point(240, 150);
            this.txtRoomID.Font = new Font("Segoe UI", 12);
            this.txtRoomID.PlaceholderText = "Nhập mã phòng";

            // Nút Tham gia (Bên trái)
            this.btnJoinRoom.Text = "Tham gia phòng";
            this.btnJoinRoom.Size = new Size(140, 45);
            this.btnJoinRoom.Location = new Point(190, 200); // Dịch sang trái một chút
            this.btnJoinRoom.BackColor = Color.FromArgb(46, 204, 113); // Màu xanh lá
            this.btnJoinRoom.ForeColor = Color.White;
            this.btnJoinRoom.FlatStyle = FlatStyle.Flat;
            this.btnJoinRoom.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Nút Tạo phòng (Bên phải)
            this.btnCreateRoom.Text = "Tạo phòng mới";
            this.btnCreateRoom.Size = new Size(140, 45);
            this.btnCreateRoom.Location = new Point(350, 200); // Đặt cạnh nút Tham gia
            this.btnCreateRoom.BackColor = Color.FromArgb(52, 152, 219); // Màu xanh dương
            this.btnCreateRoom.ForeColor = Color.White;
            this.btnCreateRoom.FlatStyle = FlatStyle.Flat;
            this.btnCreateRoom.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Thêm các control vào Panel Manager
            this.pnlRoomManager.Controls.Add(lblRoomManagerTitle);
            this.pnlRoomManager.Controls.Add(txtRoomID);
            this.pnlRoomManager.Controls.Add(btnJoinRoom);
            this.pnlRoomManager.Controls.Add(btnCreateRoom); 

            // THÊM pnlRoomManager VÀO pnlCenter
            this.pnlCenter.Controls.Add(pnlRoomManager);
            this.pnlRoomManager.BringToFront();
            // Cấu hình nút rời phòng (Leave Room)
            // --- Khởi tạo btnLeaveRoom ---
            this.btnLeaveRoom = new System.Windows.Forms.Button();
            this.btnLeaveRoom.Text = "Rời phòng";
            this.btnLeaveRoom.BackColor = Color.FromArgb(231, 76, 60); // Màu đỏ (Alizarin)
            this.btnLeaveRoom.ForeColor = Color.White;
            this.btnLeaveRoom.FlatStyle = FlatStyle.Flat;
            this.btnLeaveRoom.Size = new Size(100, 30);
            this.btnLeaveRoom.Location = new Point(10, 15); // Đặt bên trái thanh header
            this.btnLeaveRoom.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnLeaveRoom.Visible = false; // Mặc định ẩn, chỉ hiện khi đã vào phòng

            // Thêm vào pnlChatHeader
            this.pnlChatHeader.Controls.Add(btnLeaveRoom);
            // Đảm bảo nút này nằm trên cùng để click được
            this.btnLeaveRoom.BringToFront();
            // 
            // --- Khởi tạo btnDeleteRoom ---
            // 
            this.btnDeleteRoom = new System.Windows.Forms.Button();
            this.btnDeleteRoom.Text = "Xóa phòng";
            this.btnDeleteRoom.BackColor = Color.Firebrick; // Màu đỏ đậm để phân biệt với nút Rời phòng
            this.btnDeleteRoom.ForeColor = Color.White;
            this.btnDeleteRoom.FlatStyle = FlatStyle.Flat;
            this.btnDeleteRoom.Size = new Size(100, 30);
            // Đặt vị trí bên cạnh nút Rời phòng (btnLeaveRoom đang ở tọa độ 10, 15)
            this.btnDeleteRoom.Location = new Point(120, 15);
            this.btnDeleteRoom.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnDeleteRoom.Visible = false; // Mặc định ẩn, chỉ hiện cho chủ phòng

            // Thêm vào pnlChatHeader
            this.pnlChatHeader.Controls.Add(btnDeleteRoom);
            this.btnDeleteRoom.BringToFront();
        }


        #endregion
        // Các vùng bố cục chính (Panels)
        private System.Windows.Forms.Panel pnlLeft;        // Cột bên trái (Danh sách Clients)
        private System.Windows.Forms.Panel pnlRight;       // Cột bên phải (Thông báo)
        private System.Windows.Forms.Panel pnlCenter;      // Vùng ở giữa (Khung chat)
        private System.Windows.Forms.Panel pnlChatHeader;  // Thanh tiêu đề nhóm
        private System.Windows.Forms.Panel pnlInputArea;   // Vùng nhập tin nhắn
        private System.Windows.Forms.Label lblOnlineHeader;
        private System.Windows.Forms.Panel pnlOnlineList; // Panel chứa danh sách client có scroll
                                                          // Thêm vào khu vực khai báo biến (cuối file Designer)
        private System.Windows.Forms.Panel pnlRoomManager;
        private System.Windows.Forms.TextBox txtRoomID;
        private System.Windows.Forms.Button btnJoinRoom;
        private System.Windows.Forms.Label lblRoomManagerTitle;
        private System.Windows.Forms.Button btnLeaveRoom;
        private System.Windows.Forms.Button btnCreateRoom; // Thêm nút tạo phòng
        private System.Windows.Forms.Button btnDeleteRoom; // Nút xóa phòng dành cho chủ phòng


        // Các điều khiển hiển thị
        private System.Windows.Forms.ListBox lbClients;    // (7) ListBox clients
        private System.Windows.Forms.RichTextBox rtbChat;  // (9) RichTextBox chat
        private System.Windows.Forms.TextBox txtMessage;   // (11) Ô nhập tin nhắn
        private System.Windows.Forms.Button btnSend;       // (11) Nút gửi
        private System.Windows.Forms.Label lblRoomInfo;    // (8) Nhóm chung (Broadcast)
        private System.Windows.Forms.FlowLayoutPanel flpSystemLogs; // (10) Panel thông báo
        private System.Windows.Forms.Button btnGroupChat;
        private System.Windows.Forms.Label lblGroupNotify;
        public System.Windows.Forms.Label lblMyName;
    }
}

