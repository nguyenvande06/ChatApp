namespace Client
{
    partial class UC_Login
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
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.lblTitle = new Label();
            this.lblSubTitle = new Label();
            this.lblUsername = new Label();
            this.txtUsername = new TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();

            this.SuspendLayout();



            // --- lblTitle ---
            this.lblTitle.Text = "Đăng nhập";
            this.lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.lblTitle.Location = new Point(50, 80);
            this.lblTitle.Size = new Size(300, 40);
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // --- lblUsername & txtUsername ---
            this.lblUsername.Text = "Username";
            this.lblUsername.Location = new Point(50, 160);
            this.lblUsername.AutoSize = true;

            this.txtUsername.Text = "";
            this.txtUsername.Location = new Point(50, 185);
            this.txtUsername.Size = new Size(300, 35);
            this.txtUsername.BackColor = Color.FromArgb(245, 245, 240);

            // --- lblPassword & txtPassword ---
            this.lblPassword.Text = "Password";
            this.lblPassword.Location = new Point(50, 240);
            this.lblPassword.AutoSize = true;

            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Location = new Point(50, 265);
            this.txtPassword.Size = new Size(300, 35);
            this.txtPassword.BackColor = Color.FromArgb(245, 245, 240);

            // --- btnLogin ---
            this.btnLogin.Text = "Kết nối đến server →";
            this.btnLogin.BackColor = Color.FromArgb(51, 103, 184);
            this.btnLogin.ForeColor = Color.White;
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnLogin.Location = new Point(50, 330);
            this.btnLogin.Size = new Size(300, 50);

            // --- Cấu hình UC_Login ---
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnLogin);
            this.Size = new Size(400, 500);
            this.BackColor = Color.White;

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
    }
}
