namespace NativeServer
{
    partial class SocketForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ServerSocket = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtServerMsg = new System.Windows.Forms.TextBox();
            this.ClientSocket = new System.Windows.Forms.GroupBox();
            this.txtExeArgs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtExePath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtClientMsg = new System.Windows.Forms.TextBox();
            this.btnDownloadFile = new System.Windows.Forms.Button();
            this.btnCallExe = new System.Windows.Forms.Button();
            this.btnSayHello = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblIp = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.cboClient = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ServerSocket.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ClientSocket.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 51);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ServerSocket);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ClientSocket);
            this.splitContainer1.Size = new System.Drawing.Size(749, 501);
            this.splitContainer1.SplitterDistance = 210;
            this.splitContainer1.TabIndex = 0;
            // 
            // ServerSocket
            // 
            this.ServerSocket.Controls.Add(this.groupBox1);
            this.ServerSocket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerSocket.Location = new System.Drawing.Point(0, 0);
            this.ServerSocket.Name = "ServerSocket";
            this.ServerSocket.Size = new System.Drawing.Size(749, 210);
            this.ServerSocket.TabIndex = 0;
            this.ServerSocket.TabStop = false;
            this.ServerSocket.Text = "Server";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtServerMsg);
            this.groupBox1.Location = new System.Drawing.Point(6, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(740, 106);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Message:";
            // 
            // txtServerMsg
            // 
            this.txtServerMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtServerMsg.Location = new System.Drawing.Point(3, 17);
            this.txtServerMsg.Multiline = true;
            this.txtServerMsg.Name = "txtServerMsg";
            this.txtServerMsg.Size = new System.Drawing.Size(734, 86);
            this.txtServerMsg.TabIndex = 0;
            // 
            // ClientSocket
            // 
            this.ClientSocket.Controls.Add(this.label3);
            this.ClientSocket.Controls.Add(this.cboClient);
            this.ClientSocket.Controls.Add(this.txtExeArgs);
            this.ClientSocket.Controls.Add(this.label2);
            this.ClientSocket.Controls.Add(this.label1);
            this.ClientSocket.Controls.Add(this.txtExePath);
            this.ClientSocket.Controls.Add(this.groupBox2);
            this.ClientSocket.Controls.Add(this.btnDownloadFile);
            this.ClientSocket.Controls.Add(this.btnCallExe);
            this.ClientSocket.Controls.Add(this.btnSayHello);
            this.ClientSocket.Controls.Add(this.btnConnect);
            this.ClientSocket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClientSocket.Location = new System.Drawing.Point(0, 0);
            this.ClientSocket.Name = "ClientSocket";
            this.ClientSocket.Size = new System.Drawing.Size(749, 287);
            this.ClientSocket.TabIndex = 0;
            this.ClientSocket.TabStop = false;
            this.ClientSocket.Text = "Client";
            // 
            // txtExeArgs
            // 
            this.txtExeArgs.Location = new System.Drawing.Point(456, 108);
            this.txtExeArgs.Name = "txtExeArgs";
            this.txtExeArgs.Size = new System.Drawing.Size(172, 21);
            this.txtExeArgs.TabIndex = 7;
            this.txtExeArgs.Text = "aa,bb";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Args(Comma separated):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Exe Path:";
            // 
            // txtExePath
            // 
            this.txtExePath.Location = new System.Drawing.Point(95, 108);
            this.txtExePath.Name = "txtExePath";
            this.txtExePath.Size = new System.Drawing.Size(202, 21);
            this.txtExePath.TabIndex = 4;
            this.txtExePath.Text = "test/ExeTest.exe";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtClientMsg);
            this.groupBox2.Location = new System.Drawing.Point(6, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(740, 120);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Message:";
            // 
            // txtClientMsg
            // 
            this.txtClientMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtClientMsg.Location = new System.Drawing.Point(3, 17);
            this.txtClientMsg.Multiline = true;
            this.txtClientMsg.Name = "txtClientMsg";
            this.txtClientMsg.Size = new System.Drawing.Size(734, 100);
            this.txtClientMsg.TabIndex = 0;
            // 
            // btnDownloadFile
            // 
            this.btnDownloadFile.Location = new System.Drawing.Point(129, 70);
            this.btnDownloadFile.Name = "btnDownloadFile";
            this.btnDownloadFile.Size = new System.Drawing.Size(137, 23);
            this.btnDownloadFile.TabIndex = 3;
            this.btnDownloadFile.Text = "DownloadFile";
            this.btnDownloadFile.UseVisualStyleBackColor = true;
            // 
            // btnCallExe
            // 
            this.btnCallExe.Location = new System.Drawing.Point(649, 106);
            this.btnCallExe.Name = "btnCallExe";
            this.btnCallExe.Size = new System.Drawing.Size(75, 23);
            this.btnCallExe.TabIndex = 2;
            this.btnCallExe.Text = "CallExe";
            this.btnCallExe.UseVisualStyleBackColor = true;
            this.btnCallExe.Click += new System.EventHandler(this.btnCallExe_Click);
            // 
            // btnSayHello
            // 
            this.btnSayHello.Location = new System.Drawing.Point(35, 70);
            this.btnSayHello.Name = "btnSayHello";
            this.btnSayHello.Size = new System.Drawing.Size(75, 23);
            this.btnSayHello.TabIndex = 1;
            this.btnSayHello.Text = "SayHello";
            this.btnSayHello.UseVisualStyleBackColor = true;
            this.btnSayHello.Click += new System.EventHandler(this.btnSayHello_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(435, 29);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(184, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Create New Client ";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Location = new System.Drawing.Point(50, 20);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(23, 12);
            this.lblIp.TabIndex = 1;
            this.lblIp.Text = "IP:";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(79, 17);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(263, 21);
            this.txtIp.TabIndex = 2;
            this.txtIp.Text = "127.0.0.1";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(365, 20);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(35, 12);
            this.lblPort.TabIndex = 3;
            this.lblPort.Text = "PORT:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(406, 17);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(94, 21);
            this.txtPort.TabIndex = 4;
            // 
            // cboClient
            // 
            this.cboClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClient.FormattingEnabled = true;
            this.cboClient.Location = new System.Drawing.Point(126, 31);
            this.cboClient.Name = "cboClient";
            this.cboClient.Size = new System.Drawing.Size(291, 20);
            this.cboClient.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "Client List:";
            // 
            // SocketTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 555);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.lblIp);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SocketTest";
            this.Text = "ServerSocketTest";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ServerSocket.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ClientSocket.ResumeLayout(false);
            this.ClientSocket.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox ServerSocket;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.GroupBox ClientSocket;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDownloadFile;
        private System.Windows.Forms.Button btnCallExe;
        private System.Windows.Forms.Button btnSayHello;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtServerMsg;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtClientMsg;
        private System.Windows.Forms.TextBox txtExeArgs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboClient;
    }
}