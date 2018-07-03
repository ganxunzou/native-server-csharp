namespace NativeServer
{
    partial class ClientForm
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
            this.ClientSocket = new System.Windows.Forms.GroupBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ckAsync = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboClient = new System.Windows.Forms.ComboBox();
            this.txtExeArgs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtExePath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtClientMSg = new System.Windows.Forms.TextBox();
            this.btnDownloadFile = new System.Windows.Forms.Button();
            this.btnCallExe = new System.Windows.Forms.Button();
            this.btnSayHello = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.ClientSocket.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientSocket
            // 
            this.ClientSocket.Controls.Add(this.btnOpenFile);
            this.ClientSocket.Controls.Add(this.txtFilePath);
            this.ClientSocket.Controls.Add(this.label6);
            this.ClientSocket.Controls.Add(this.txtSavePath);
            this.ClientSocket.Controls.Add(this.label5);
            this.ClientSocket.Controls.Add(this.txtUrl);
            this.ClientSocket.Controls.Add(this.label4);
            this.ClientSocket.Controls.Add(this.ckAsync);
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
            this.ClientSocket.Size = new System.Drawing.Size(834, 400);
            this.ClientSocket.TabIndex = 1;
            this.ClientSocket.TabStop = false;
            this.ClientSocket.Text = "Client";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(67, 93);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(227, 21);
            this.txtUrl.TabIndex = 12;
            this.txtUrl.Text = "http://127.0.0.1/1.doc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "URL:";
            // 
            // ckAsync
            // 
            this.ckAsync.AutoSize = true;
            this.ckAsync.Location = new System.Drawing.Point(650, 63);
            this.ckAsync.Name = "ckAsync";
            this.ckAsync.Size = new System.Drawing.Size(54, 16);
            this.ckAsync.TabIndex = 10;
            this.ckAsync.Text = "async";
            this.ckAsync.UseVisualStyleBackColor = true;
            this.ckAsync.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "Client List:";
            // 
            // cboClient
            // 
            this.cboClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClient.FormattingEnabled = true;
            this.cboClient.Location = new System.Drawing.Point(109, 31);
            this.cboClient.Name = "cboClient";
            this.cboClient.Size = new System.Drawing.Size(291, 20);
            this.cboClient.TabIndex = 8;
            // 
            // txtExeArgs
            // 
            this.txtExeArgs.Location = new System.Drawing.Point(458, 61);
            this.txtExeArgs.Name = "txtExeArgs";
            this.txtExeArgs.Size = new System.Drawing.Size(172, 21);
            this.txtExeArgs.TabIndex = 7;
            this.txtExeArgs.Text = "aa,bb";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Args(Comma separated):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Exe Path:";
            // 
            // txtExePath
            // 
            this.txtExePath.Location = new System.Drawing.Point(85, 61);
            this.txtExePath.Name = "txtExePath";
            this.txtExePath.Size = new System.Drawing.Size(227, 21);
            this.txtExePath.TabIndex = 4;
            this.txtExePath.Text = "test/ExeTest.exe";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtClientMSg);
            this.groupBox2.Location = new System.Drawing.Point(6, 190);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(825, 201);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Message:";
            // 
            // txtClientMSg
            // 
            this.txtClientMSg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtClientMSg.Location = new System.Drawing.Point(3, 17);
            this.txtClientMSg.Multiline = true;
            this.txtClientMSg.Name = "txtClientMSg";
            this.txtClientMSg.Size = new System.Drawing.Size(819, 181);
            this.txtClientMSg.TabIndex = 0;
            // 
            // btnDownloadFile
            // 
            this.btnDownloadFile.Location = new System.Drawing.Point(650, 91);
            this.btnDownloadFile.Name = "btnDownloadFile";
            this.btnDownloadFile.Size = new System.Drawing.Size(137, 23);
            this.btnDownloadFile.TabIndex = 3;
            this.btnDownloadFile.Text = "DownloadFile";
            this.btnDownloadFile.UseVisualStyleBackColor = true;
            this.btnDownloadFile.Click += new System.EventHandler(this.btnDownloadFile_Click);
            // 
            // btnCallExe
            // 
            this.btnCallExe.Location = new System.Drawing.Point(710, 59);
            this.btnCallExe.Name = "btnCallExe";
            this.btnCallExe.Size = new System.Drawing.Size(93, 23);
            this.btnCallExe.TabIndex = 2;
            this.btnCallExe.Text = "CallExe";
            this.btnCallExe.UseVisualStyleBackColor = true;
            this.btnCallExe.Click += new System.EventHandler(this.btnCallExe_Click);
            // 
            // btnSayHello
            // 
            this.btnSayHello.Location = new System.Drawing.Point(622, 29);
            this.btnSayHello.Name = "btnSayHello";
            this.btnSayHello.Size = new System.Drawing.Size(75, 23);
            this.btnSayHello.TabIndex = 1;
            this.btnSayHello.Text = "SayHello";
            this.btnSayHello.UseVisualStyleBackColor = true;
            this.btnSayHello.Click += new System.EventHandler(this.btnSayHello_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(418, 29);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(184, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Create New Client ";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(318, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "savePath:";
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(394, 93);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(227, 21);
            this.txtSavePath.TabIndex = 14;
            this.txtSavePath.Text = "d:\\1.doc";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(88, 132);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(533, 21);
            this.txtFilePath.TabIndex = 16;
            this.txtFilePath.Text = "d:\\1.doc";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "FilePath:";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(650, 130);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(137, 23);
            this.btnOpenFile.TabIndex = 17;
            this.btnOpenFile.Text = "OpenFile";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 400);
            this.Controls.Add(this.ClientSocket);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.ClientSocket.ResumeLayout(false);
            this.ClientSocket.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ClientSocket;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboClient;
        private System.Windows.Forms.TextBox txtExeArgs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExePath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtClientMSg;
        private System.Windows.Forms.Button btnDownloadFile;
        private System.Windows.Forms.Button btnCallExe;
        private System.Windows.Forms.Button btnSayHello;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.CheckBox ckAsync;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label6;
    }
}