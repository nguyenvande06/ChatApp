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
    public partial class UC_Login : UserControl
    {

        public UC_Login()
        {
            InitializeComponent();
            btnLogin.Click += BtnLogin_Click;
        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập Username!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.ParentForm is Form1 mainForm)
            {
                // LƯU TÊN VÀO FORM CHÍNH TRƯỚC KHI ĐI TIẾP
                mainForm.MyUsername = username;

                mainForm.ShowConnectionScreen();
            }
        }
    }
}
