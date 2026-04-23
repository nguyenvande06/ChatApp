namespace Server
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            pnlTop = new Panel();
            txtIP = new TextBox();
            txtPort = new TextBox();
            btnStart = new Button();
            btnStop = new Button();
            rtbLog = new RichTextBox();
            lbClients = new ListBox();
            pnlStatus = new Panel();
            lblStatus = new Label();
            lblClientCount = new Label();
            splitMain = new SplitContainer();
            lblLogHeader = new Label();
            lblClientHeader = new Label();
            pnlTop.SuspendLayout();
            pnlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.Panel1.SuspendLayout();
            splitMain.Panel2.SuspendLayout();
            splitMain.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.WhiteSmoke;
            pnlTop.Controls.Add(txtIP);
            pnlTop.Controls.Add(txtPort);
            pnlTop.Controls.Add(btnStart);
            pnlTop.Controls.Add(btnStop);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Margin = new Padding(3, 4, 3, 4);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(914, 80);
            pnlTop.TabIndex = 1;
            // 
            // txtIP
            // 
            txtIP.Location = new Point(11, 27);
            txtIP.Margin = new Padding(3, 4, 3, 4);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(137, 27);
            txtIP.TabIndex = 0;
            txtIP.Text = "127.0.0.1";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(160, 27);
            txtPort.Margin = new Padding(3, 4, 3, 4);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(68, 27);
            txtPort.TabIndex = 1;
            txtPort.Text = "8888";
            // 
            // btnStart
            //
            btnStart.BackColor = Color.LightGreen;
            btnStart.Cursor = Cursors.Default;
            btnStart.Location = new Point(240, 20);
            btnStart.Margin = new Padding(3, 4, 3, 4);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(114, 40);
            btnStart.TabIndex = 2;
            btnStart.Text = "Start Server";
            btnStart.UseVisualStyleBackColor = false;

            // 
            // btnStop
            // 
            btnStop.BackColor = Color.LightCoral;
            btnStop.Cursor = Cursors.Default;
            btnStop.Location = new Point(366, 20);
            btnStop.Margin = new Padding(3, 4, 3, 4);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(114, 40);
            btnStop.TabIndex = 3;
            btnStop.Text = "Stop Server";
            btnStop.UseVisualStyleBackColor = false;
            //
            // rtbLog
            // 
            rtbLog.BackColor = Color.FloralWhite;
            rtbLog.Dock = DockStyle.Fill;
            rtbLog.Location = new Point(0, 0);
            rtbLog.Margin = new Padding(3, 4, 3, 4);
            rtbLog.Name = "rtbLog";
            rtbLog.ReadOnly = true;
            rtbLog.Size = new Size(737, 548);
            rtbLog.TabIndex = 0;
            rtbLog.Text = "";
            // 
            // lbClients
            // 
            lbClients.BackColor = Color.AliceBlue;
            lbClients.BorderStyle = BorderStyle.FixedSingle;
            lbClients.Dock = DockStyle.Fill;
            lbClients.IntegralHeight = false;
            lbClients.Location = new Point(0, 0);
            lbClients.Margin = new Padding(3, 4, 3, 4);
            lbClients.Name = "lbClients";
            lbClients.Size = new Size(172, 547);
            lbClients.TabIndex = 0;
            // 
            // pnlStatus
            // 
            pnlStatus.BorderStyle = BorderStyle.FixedSingle;
            pnlStatus.Controls.Add(lblStatus);
            pnlStatus.Controls.Add(lblClientCount);
            pnlStatus.Dock = DockStyle.Bottom;
            pnlStatus.Location = new Point(0, 628);
            pnlStatus.Margin = new Padding(3, 4, 3, 4);
            pnlStatus.Name = "pnlStatus";
            pnlStatus.Size = new Size(914, 39);
            pnlStatus.TabIndex = 2;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(6, 7);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(108, 20);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "● Server Ready";
            // 
            // lblClientCount
            // 
            lblClientCount.Dock = DockStyle.Right;
            lblClientCount.Location = new Point(798, 0);
            lblClientCount.Name = "lblClientCount";
            lblClientCount.Size = new Size(114, 37);
            lblClientCount.TabIndex = 1;
            lblClientCount.Text = "0 clients online";
            lblClientCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // splitMain
            // 
            splitMain.Dock = DockStyle.Fill;
            splitMain.Location = new Point(0, 80);
            splitMain.Margin = new Padding(3, 4, 3, 4);
            splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.Controls.Add(rtbLog);
            splitMain.Panel1.Controls.Add(lblLogHeader);
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.Controls.Add(lbClients);
            splitMain.Panel2.Controls.Add(lblClientHeader);
            splitMain.Panel2.Padding = new Padding(0, 0, 0, 1);
            splitMain.Size = new Size(914, 548);
            splitMain.SplitterDistance = 737;
            splitMain.SplitterWidth = 5;
            splitMain.TabIndex = 0;
            // 
            // lblLogHeader
            // 
            lblLogHeader.Location = new Point(0, 0);
            lblLogHeader.Name = "lblLogHeader";
            lblLogHeader.Size = new Size(114, 31);
            lblLogHeader.TabIndex = 1;
            // 
            // lblClientHeader
            // 
            lblClientHeader.Location = new Point(0, 0);
            lblClientHeader.Name = "lblClientHeader";
            lblClientHeader.Size = new Size(114, 31);
            lblClientHeader.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 667);
            Controls.Add(splitMain);
            Controls.Add(pnlTop);
            Controls.Add(pnlStatus);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Multi-Client Server Manager";
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlStatus.ResumeLayout(false);
            pnlStatus.PerformLayout();
            splitMain.Panel1.ResumeLayout(false);
            splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit();
            splitMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        // Khai báo biến thành phần (BẮT BUỘC PHẢI CÓ)
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.ListBox lbClients;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblClientCount;
        private SplitContainer splitMain;
        private Label lblLogHeader;
        private Label lblClientHeader;
    }
}