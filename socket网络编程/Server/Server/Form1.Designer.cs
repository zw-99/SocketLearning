namespace Server
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.cobUsers = new System.Windows.Forms.ComboBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.btnZD = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(45, 17);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(100, 21);
            this.txtServer.TabIndex = 0;
            this.txtServer.Text = "192.168.1.109";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(151, 17);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(42, 21);
            this.txtPort.TabIndex = 1;
            this.txtPort.Text = "500";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(314, 18);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(66, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开始监听";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cobUsers
            // 
            this.cobUsers.FormattingEnabled = true;
            this.cobUsers.Location = new System.Drawing.Point(386, 20);
            this.cobUsers.Name = "cobUsers";
            this.cobUsers.Size = new System.Drawing.Size(225, 20);
            this.cobUsers.TabIndex = 3;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(45, 61);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(566, 119);
            this.txtLog.TabIndex = 4;
            this.txtLog.WordWrap = false;
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(45, 196);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMsg.Size = new System.Drawing.Size(566, 119);
            this.txtMsg.TabIndex = 5;
            this.txtMsg.WordWrap = false;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(473, 334);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(56, 23);
            this.btnSelect.TabIndex = 6;
            this.btnSelect.Text = "选择";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(536, 334);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(75, 23);
            this.btnSendFile.TabIndex = 7;
            this.btnSendFile.Text = "发送文件";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(45, 336);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(422, 21);
            this.txtPath.TabIndex = 8;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(391, 367);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(75, 23);
            this.btnSendMessage.TabIndex = 9;
            this.btnSendMessage.Text = "发送消息";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // btnZD
            // 
            this.btnZD.Location = new System.Drawing.Point(495, 367);
            this.btnZD.Name = "btnZD";
            this.btnZD.Size = new System.Drawing.Size(75, 23);
            this.btnZD.TabIndex = 10;
            this.btnZD.Text = "震动";
            this.btnZD.UseVisualStyleBackColor = true;
            this.btnZD.Click += new System.EventHandler(this.btnZD_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 402);
            this.Controls.Add(this.btnZD);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnSendFile);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.cobUsers);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtServer);
            this.Name = "Form1";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cobUsers;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button btnZD;
    }
}

