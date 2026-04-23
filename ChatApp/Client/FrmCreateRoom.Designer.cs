namespace Client
{
    partial class FrmCreateRoom
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtRoomID = new TextBox();
            txtPassword = new TextBox();
            btnConfirm = new Button();
            lblTitle = new Label();
            lblRoomID = new Label();
            lblPass = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(320, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "TẠO PHÒNG MỚI";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRoomID
            // 
            lblRoomID.AutoSize = true;
            lblRoomID.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRoomID.Location = new Point(30, 70);
            lblRoomID.Name = "lblRoomID";
            lblRoomID.Size = new Size(82, 20);
            lblRoomID.TabIndex = 4;
            lblRoomID.Text = "Mã phòng:";
            // 
            // txtRoomID
            // 
            txtRoomID.Font = new Font("Segoe UI", 11F);
            txtRoomID.Location = new Point(30, 95);
            txtRoomID.Name = "txtRoomID";
            txtRoomID.PlaceholderText = "Ví dụ: NHOM_HOC_TAP";
            txtRoomID.Size = new Size(260, 32);
            txtRoomID.TabIndex = 1;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPass.Location = new Point(30, 140);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(149, 20);
            lblPass.TabIndex = 5;
            lblPass.Text = "Mật khẩu (tùy chọn):";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(30, 165);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Để trống nếu không dùng";
            txtPassword.Size = new Size(260, 32);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.FromArgb(52, 152, 219);
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Location = new Point(30, 220);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(260, 45);
            btnConfirm.TabIndex = 3;
            btnConfirm.Text = "XÁC NHẬN TẠO";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // FrmCreateRoom
            // 
            AcceptButton = btnConfirm; // Nhấn Enter là xác nhận luôn
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(320, 300);
            Controls.Add(lblPass);
            Controls.Add(lblRoomID);
            Controls.Add(btnConfirm);
            Controls.Add(txtPassword);
            Controls.Add(txtRoomID);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog; // Không cho kéo giãn
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCreateRoom";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Create New Room";
            ResumeLayout(false);
            PerformLayout();
        }
        // Khai báo các biến ở dưới cùng của file Designer:
        private TextBox txtRoomID;
        private TextBox txtPassword;
        private Button btnConfirm;
        private Label lblTitle;
        private Label lblRoomID;
        private Label lblPass;

        #endregion
    }
}