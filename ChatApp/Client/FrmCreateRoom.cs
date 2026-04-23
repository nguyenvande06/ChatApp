using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FrmCreateRoom : Form
    {
        // 1. Tạo các biến để giữ giá trị chắc chắn
        private string _roomId = "";
        private string _password = "";

        // 2. Sửa lại để trả về biến đã lưu
        public string RoomID => _roomId;
        public string Password => _password;

        public FrmCreateRoom()
        {
            InitializeComponent();
        }

        // Hàm dùng cho trường hợp NHẬP PASS để Join
        public void SetJoinMode(string roomId)
        {
            this._roomId = roomId; // Lưu ID phòng muốn vào vào đây luôn

            lblTitle.Text = "XÁC THỰC PHÒNG";
            btnConfirm.Text = "VÀO PHÒNG";
            txtRoomID.Visible = false;
            lblRoomID.Visible = false;
            lblPass.Text = $"Phòng {roomId} yêu cầu mật khẩu:";

            // Đẩy ô nhập pass lên vị trí đẹp
            lblPass.Location = new Point(30, 70);
            txtPassword.Location = new Point(30, 95);
            btnConfirm.Location = new Point(30, 150);
            this.ClientSize = new Size(320, 230);
            txtPassword.Focus();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 3. QUAN TRỌNG: Gán giá trị từ giao diện vào biến trước khi đóng
            if (txtRoomID.Visible) // Nếu đang ở chế độ TẠO PHÒNG
            {
                _roomId = txtRoomID.Text.Trim();
                if (string.IsNullOrEmpty(_roomId))
                {
                    MessageBox.Show("Vui lòng nhập mã phòng!");
                    return;
                }
            }
            // Luôn lấy password
            _password = txtPassword.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close(); // Đóng form sau khi đã lưu dữ liệu vào _roomId và _password
        }
    }
}
