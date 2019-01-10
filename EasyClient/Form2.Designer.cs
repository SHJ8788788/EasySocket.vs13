namespace EasyClient
{
    partial class Form2
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbGetVersion = new System.Windows.Forms.TextBox();
            this.btnGetVersion = new System.Windows.Forms.Button();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.btnGetMessage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbGetMessage = new System.Windows.Forms.TextBox();
            this.tbnum = new System.Windows.Forms.TextBox();
            this.btnGetMessage10s = new System.Windows.Forms.Button();
            this.btn100000s = new System.Windows.Forms.Button();
            this.tbGetMessage10s = new System.Windows.Forms.TextBox();
            this.tbVoidSetMessage = new System.Windows.Forms.TextBox();
            this.btnVoidSetMessage = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogoff = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.lbxMsg = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbNum = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(685, 495);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.lbxMsg);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(677, 469);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "测试页1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbGetVersion);
            this.groupBox2.Controls.Add(this.btnGetVersion);
            this.groupBox2.Controls.Add(this.cbType);
            this.groupBox2.Controls.Add(this.btnGetMessage);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbGetMessage);
            this.groupBox2.Controls.Add(this.tbnum);
            this.groupBox2.Controls.Add(this.btnGetMessage10s);
            this.groupBox2.Controls.Add(this.btn100000s);
            this.groupBox2.Controls.Add(this.tbGetMessage10s);
            this.groupBox2.Controls.Add(this.tbVoidSetMessage);
            this.groupBox2.Controls.Add(this.btnVoidSetMessage);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(671, 198);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "测试2";
            // 
            // tbGetVersion
            // 
            this.tbGetVersion.Location = new System.Drawing.Point(6, 20);
            this.tbGetVersion.Name = "tbGetVersion";
            this.tbGetVersion.Size = new System.Drawing.Size(244, 21);
            this.tbGetVersion.TabIndex = 1;
            // 
            // btnGetVersion
            // 
            this.btnGetVersion.Location = new System.Drawing.Point(269, 19);
            this.btnGetVersion.Name = "btnGetVersion";
            this.btnGetVersion.Size = new System.Drawing.Size(90, 23);
            this.btnGetVersion.TabIndex = 0;
            this.btnGetVersion.Text = "获取版本号";
            this.btnGetVersion.UseVisualStyleBackColor = true;
            this.btnGetVersion.Click += new System.EventHandler(this.btnGetVersion_Click);
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "打印返回信息",
            "打印返回信息10s",
            "获取版本号"});
            this.cbType.Location = new System.Drawing.Point(461, 29);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(103, 20);
            this.cbType.TabIndex = 6;
            this.cbType.Text = "打印返回信息";
            // 
            // btnGetMessage
            // 
            this.btnGetMessage.Location = new System.Drawing.Point(269, 69);
            this.btnGetMessage.Name = "btnGetMessage";
            this.btnGetMessage.Size = new System.Drawing.Size(90, 23);
            this.btnGetMessage.TabIndex = 0;
            this.btnGetMessage.Text = "打印返回信息";
            this.btnGetMessage.UseVisualStyleBackColor = true;
            this.btnGetMessage.Click += new System.EventHandler(this.btnGetMessage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(519, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "次";
            // 
            // tbGetMessage
            // 
            this.tbGetMessage.Location = new System.Drawing.Point(6, 70);
            this.tbGetMessage.Name = "tbGetMessage";
            this.tbGetMessage.Size = new System.Drawing.Size(244, 21);
            this.tbGetMessage.TabIndex = 1;
            // 
            // tbnum
            // 
            this.tbnum.Location = new System.Drawing.Point(457, 83);
            this.tbnum.Name = "tbnum";
            this.tbnum.Size = new System.Drawing.Size(56, 21);
            this.tbnum.TabIndex = 4;
            this.tbnum.Text = "100";
            // 
            // btnGetMessage10s
            // 
            this.btnGetMessage10s.Location = new System.Drawing.Point(269, 114);
            this.btnGetMessage10s.Name = "btnGetMessage10s";
            this.btnGetMessage10s.Size = new System.Drawing.Size(124, 23);
            this.btnGetMessage10s.TabIndex = 0;
            this.btnGetMessage10s.Text = "打印返回信息10s";
            this.btnGetMessage10s.UseVisualStyleBackColor = true;
            this.btnGetMessage10s.Click += new System.EventHandler(this.btnGetMessage10s_Click);
            // 
            // btn100000s
            // 
            this.btn100000s.Location = new System.Drawing.Point(455, 113);
            this.btn100000s.Name = "btn100000s";
            this.btn100000s.Size = new System.Drawing.Size(81, 23);
            this.btn100000s.TabIndex = 3;
            this.btn100000s.Text = "100000次测试";
            this.btn100000s.UseVisualStyleBackColor = true;
            this.btn100000s.Click += new System.EventHandler(this.btn100000s_Click);
            // 
            // tbGetMessage10s
            // 
            this.tbGetMessage10s.Location = new System.Drawing.Point(6, 115);
            this.tbGetMessage10s.Name = "tbGetMessage10s";
            this.tbGetMessage10s.Size = new System.Drawing.Size(244, 21);
            this.tbGetMessage10s.TabIndex = 1;
            // 
            // tbVoidSetMessage
            // 
            this.tbVoidSetMessage.Location = new System.Drawing.Point(6, 152);
            this.tbVoidSetMessage.Name = "tbVoidSetMessage";
            this.tbVoidSetMessage.Size = new System.Drawing.Size(244, 21);
            this.tbVoidSetMessage.TabIndex = 1;
            // 
            // btnVoidSetMessage
            // 
            this.btnVoidSetMessage.Location = new System.Drawing.Point(269, 151);
            this.btnVoidSetMessage.Name = "btnVoidSetMessage";
            this.btnVoidSetMessage.Size = new System.Drawing.Size(124, 23);
            this.btnVoidSetMessage.TabIndex = 0;
            this.btnVoidSetMessage.Text = "无返回打印信息";
            this.btnVoidSetMessage.UseVisualStyleBackColor = true;
            this.btnVoidSetMessage.Click += new System.EventHandler(this.btnVoidSetMessage_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbNum);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnInit);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnLogin);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnLogoff);
            this.groupBox1.Controls.Add(this.tbPassword);
            this.groupBox1.Controls.Add(this.tbUser);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(671, 100);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "测试1";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(11, 20);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(11, 62);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(102, 20);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(75, 23);
            this.btnInit.TabIndex = 7;
            this.btnInit.Text = "计数器初始化";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(329, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "密码";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(218, 20);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "登陆";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(329, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "帐号";
            // 
            // btnLogoff
            // 
            this.btnLogoff.Location = new System.Drawing.Point(218, 62);
            this.btnLogoff.Name = "btnLogoff";
            this.btnLogoff.Size = new System.Drawing.Size(75, 23);
            this.btnLogoff.TabIndex = 7;
            this.btnLogoff.Text = "登出";
            this.btnLogoff.UseVisualStyleBackColor = true;
            this.btnLogoff.Click += new System.EventHandler(this.btnLogoff_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(365, 62);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(100, 21);
            this.tbPassword.TabIndex = 8;
            this.tbPassword.Text = "888";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(365, 22);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(100, 21);
            this.tbUser.TabIndex = 8;
            this.tbUser.Text = "A8888";
            // 
            // lbxMsg
            // 
            this.lbxMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbxMsg.FormattingEnabled = true;
            this.lbxMsg.ItemHeight = 12;
            this.lbxMsg.Location = new System.Drawing.Point(3, 342);
            this.lbxMsg.Name = "lbxMsg";
            this.lbxMsg.Size = new System.Drawing.Size(671, 124);
            this.lbxMsg.TabIndex = 11;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(677, 469);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "测试页2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbNum
            // 
            this.cbNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNum.FormattingEnabled = true;
            this.cbNum.Items.AddRange(new object[] {
            "10",
            "100",
            "1000"});
            this.cbNum.Location = new System.Drawing.Point(567, 23);
            this.cbNum.Name = "cbNum";
            this.cbNum.Size = new System.Drawing.Size(60, 20);
            this.cbNum.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(512, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "连接数量";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 495);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnGetVersion;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tbGetVersion;
        private System.Windows.Forms.TextBox tbGetMessage;
        private System.Windows.Forms.Button btnGetMessage;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbGetMessage10s;
        private System.Windows.Forms.Button btnGetMessage10s;
        private System.Windows.Forms.Button btn100000s;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbnum;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.TextBox tbVoidSetMessage;
        private System.Windows.Forms.Button btnVoidSetMessage;
        private System.Windows.Forms.Button btnLogoff;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbxMsg;
        private System.Windows.Forms.ComboBox cbNum;
        private System.Windows.Forms.Label label4;
    }
}

