using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client;

namespace Client
{
    public partial class UC_KetNoi : UserControl
    {
        public UC_KetNoi()
        {
            // BẮT BUỘC PHẢI CÓ: Để vẽ giao diện từ file Designer
            InitializeComponent();
            // Gán sự kiện tại đây (hoặc gán trong Designer cũng được)
            btnConnect.Click += BtnConnect_Click;

        }
        private async void BtnConnect_Click(object sender, EventArgs e)
        {
            var mainForm = this.ParentForm as Form1;
            if (mainForm == null) return;
            // Thêm logic socket của bạn ở đây

            try
            {
                // 1. Chỉ khởi tạo Socket nếu nó chưa được tạo hoặc đã bị đóng
                if (mainForm.sckClient == null || !mainForm.sckClient.Connected)
                {
                    mainForm.sckClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPEndPoint ep = new IPEndPoint(IPAddress.Parse(txtIP.Text), int.Parse(txtPort.Text));
                    await mainForm.sckClient.ConnectAsync(ep);
                }

                // 2. Lấy Username hiện tại  // txtUsername là ô nhập tên của bạn
                string username = mainForm.MyUsername;
                byte[] sendData = Encoding.UTF8.GetBytes("CONNECT|" + username);
                mainForm.sckClient.Send(sendData);

                // 3. Đợi phản hồi bất đồng bộ từ Server (có thể là "CONNECTED_OK" hoặc "ERROR|Lý do lỗi")
                byte[] buffer = new byte[1024];

                int size = await Task.Run(() => mainForm.sckClient.Receive(buffer));

                // 4. Xử lý phản hồi
                if (size > 0)
                {
                    string response = Encoding.UTF8.GetString(buffer, 0, size);
                    if (response == "CONNECTED_OK")
                    {
                        mainForm.ShowChatScreen(mainForm.sckClient);
                    }
                    else if (response.StartsWith("ERROR"))
                    { 
                        // thông báo lỗi và quay lại màn hình nhập Username
                        MessageBox.Show(response.Split('|')[1], "Lỗi Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // QUAN TRỌNG: Đóng và hủy Socket cũ ngay tại đây
                        try
                        { 
                            mainForm.sckClient.Close();
                        }
                        catch { }
                        mainForm.sckClient = null;
                        mainForm.ShowLoginScreen(); // Quay lại để người dùng nhập tên khác

                    }
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Lỗi kết nối Socket: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
            }
        }


    }
}
