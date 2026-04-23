namespace Client
{
    partial class UC_KetNoi
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

        private void InitializeComponent()
        {
            // 1. Khởi tạo đối tượng
            lblTitle = new Label();
            lblSubTitle = new Label();
            lblIP = new Label();
            lblPort = new Label();
            txtIP = new TextBox();
            txtPort = new TextBox();
            btnConnect = new Button();

            SuspendLayout();

            // --- lblTitle ---
            lblTitle.Text = "Kết nối đến Server";
            lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitle.Location = new Point(50, 50);
            lblTitle.AutoSize = true;

            // --- lblSubTitle ---
            lblSubTitle.Text = "Nhập địa chỉ server để tiếp tục";
            lblSubTitle.Font = new Font("Segoe UI", 10);
            lblSubTitle.ForeColor = Color.Gray;
            lblSubTitle.Location = new Point(50, 90);
            lblSubTitle.AutoSize = true;

            // --- lblIP (Nhãn cho ô địa chỉ) ---
            lblIP.Text = "Địa chỉ IP:";
            lblIP.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            lblIP.Location = new System.Drawing.Point(50, 125); // Nằm ngay trên ô txtIP
            lblIP.AutoSize = true;

            // --- lblPort (Nhãn cho ô cổng) ---
            lblPort.Text = "Cổng (Port):";
            lblPort.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            lblPort.Location = new System.Drawing.Point(50, 185); // Nằm ngay trên ô txtPort
            lblPort.AutoSize = true;

            // --- txtIP ---
            txtIP.Text = "127.0.0.1";
            txtIP.Location = new Point(50, 150);
            txtIP.Size = new Size(300, 30);
            txtIP.BorderStyle = BorderStyle.FixedSingle;
            txtIP.BackColor = Color.FromArgb(232, 240, 254);

            // --- txtPort ---
            txtPort.Text = "8888";
            txtPort.Location = new Point(50, 210);
            txtPort.Size = new Size(300, 30);
            txtPort.BorderStyle = BorderStyle.FixedSingle;
            txtPort.BackColor = Color.FromArgb(248, 248, 240);

            // --- btnConnect ---
            btnConnect.Text = "Kết nối →";
            btnConnect.Location = new Point(50, 270);
            btnConnect.Size = new Size(300, 45);
            btnConnect.FlatStyle = FlatStyle.Flat;
            btnConnect.BackColor = Color.FromArgb(51, 103, 184);
            btnConnect.ForeColor = Color.White;
            btnConnect.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // --- UC_KetNoi (Chính nó) ---
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(this.lblIP);
            Controls.Add(this.lblPort);
            Controls.Add(lblTitle);
            Controls.Add(lblSubTitle);
            Controls.Add(txtIP);
            Controls.Add(txtPort);
            Controls.Add(btnConnect);
            Name = "UC_KetNoi";
            Size = new Size(400, 500);

            ResumeLayout(false);
            PerformLayout();
        }
        // Thêm đoạn này vào cuối file Designer.cs của bạn
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnConnect;
        
    }
}
