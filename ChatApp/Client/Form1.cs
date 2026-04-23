using System.Net.Sockets;

namespace Client
{
    public partial class Form1 : Form
    {
        public Socket? sckClient;
        public string MyUsername { get; set; } = "";
        public Form1()
        {
            InitializeComponent();
            ShowLoginScreen();
        }

        // Hàm này để chuyển sang màn hình Login
        public void ShowLoginScreen()
        {
            // 1. Tạo mới màn hình Login
            UC_Login login = new UC_Login();

            // 2. Thiết lập để nó lấp đầy cái Panel trên Form1
            login.Dock = DockStyle.Fill;

            // 3. Xóa màn hình "Kết nối" hiện tại và thêm màn hình "Login" vào
            pnlContainer.Controls.Clear();
            pnlContainer.Controls.Add(login);
        }
        public void ShowChatScreen(Socket connectedSocket)
        {
            this.sckClient = connectedSocket;
            this.Size = new Size(950, 650);

            UC_Chat chat = new UC_Chat(this.sckClient);
            chat.Dock = DockStyle.Fill;

            // Căn chỉnh label nằm sát góc phải
            if (chat.lblMyName != null)
            {
                chat.lblMyName.Text = "👤 " + this.MyUsername;

                // Cho phép label tự co dãn theo độ dài tên
                chat.lblMyName.AutoSize = true;

                // Ép nó dính chặt vào lề phải của pnlChatHeader
                chat.lblMyName.Dock = DockStyle.Right;

                // Căn giữa nội dung theo chiều dọc
                chat.lblMyName.TextAlign = ContentAlignment.MiddleRight;

                // Thêm khoảng cách (Margin/Padding) để không bị dính sát quá vào mép
                chat.lblMyName.Padding = new Padding(0, 0, 10, 0);

                // Đưa lên lớp trên cùng để không bị các control khác che mất
                chat.lblMyName.BringToFront();
            }

            pnlContainer.Controls.Clear();
            pnlContainer.Controls.Add(chat);
        }
        public void ShowConnectionScreen()
        {
            // 1. Tạo mới màn hình Kết nối
            UC_KetNoi uc = new UC_KetNoi();

            // 2. Thiết lập để nó lấp đầy cái Panel trên Form1
            uc.Dock = DockStyle.Fill;

            // 3. Xóa các màn hình cũ (nếu có) và thêm màn hình mới vào Panel
            pnlContainer.Controls.Clear();
            pnlContainer.Controls.Add(uc);
        }
    }
}
