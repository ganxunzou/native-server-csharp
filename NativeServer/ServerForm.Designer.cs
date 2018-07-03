namespace NativeServer
{
    partial class ServerForm
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
            this.lblIp = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cboClient = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Location = new System.Drawing.Point(20, 20);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(23, 12);
            this.lblIp.TabIndex = 1;
            this.lblIp.Text = "IP:";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(53, 17);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(263, 21);
            this.txtIp.TabIndex = 2;
            this.txtIp.Text = "127.0.0.1";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(339, 20);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(35, 12);
            this.lblPort.TabIndex = 3;
            this.lblPort.Text = "PORT:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(380, 17);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(94, 21);
            this.txtPort.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtMsg);
            this.groupBox1.Location = new System.Drawing.Point(6, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(722, 279);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Message:";
            // 
            // txtMsg
            // 
            this.txtMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMsg.Location = new System.Drawing.Point(3, 17);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(716, 259);
            this.txtMsg.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(506, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Open Client Form";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboClient
            // 
            this.cboClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClient.FormattingEnabled = true;
            this.cboClient.Location = new System.Drawing.Point(106, 58);
            this.cboClient.Name = "cboClient";
            this.cboClient.Size = new System.Drawing.Size(349, 20);
            this.cboClient.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "Client List";
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 400);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboClient);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.lblIp);
            this.Name = "ServerForm";
            this.Text = "ServerSocketTest";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cboClient;
        private System.Windows.Forms.Label label1;
    }
}