namespace EasyClient
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.staBarMain = new System.Windows.Forms.StatusBar();
            this.pnlInfo = new System.Windows.Forms.StatusBarPanel();
            this.pnlNum = new System.Windows.Forms.StatusBarPanel();
            this.lbxMsg = new System.Windows.Forms.ListBox();
            this.mnuItmRun = new System.Windows.Forms.MenuItem();
            this.mnuItmCascade = new System.Windows.Forms.MenuItem();
            this.mnuItmTileHorizontal = new System.Windows.Forms.MenuItem();
            this.mnuItmTileVertical = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuItemWindow = new System.Windows.Forms.MenuItem();
            this.mnuItmAbout = new System.Windows.Forms.MenuItem();
            this.mnuItmHelp = new System.Windows.Forms.MenuItem();
            this.mnuMain = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.mnuItmLogoff = new System.Windows.Forms.MenuItem();
            this.mnuItmExit = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlNum)).BeginInit();
            this.SuspendLayout();
            // 
            // staBarMain
            // 
            this.staBarMain.Location = new System.Drawing.Point(0, 493);
            this.staBarMain.Name = "staBarMain";
            this.staBarMain.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.pnlInfo,
            this.pnlNum});
            this.staBarMain.ShowPanels = true;
            this.staBarMain.Size = new System.Drawing.Size(916, 22);
            this.staBarMain.TabIndex = 1;
            // 
            // pnlInfo
            // 
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Width = 300;
            // 
            // pnlNum
            // 
            this.pnlNum.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.pnlNum.Name = "pnlNum";
            this.pnlNum.Width = 599;
            // 
            // lbxMsg
            // 
            this.lbxMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbxMsg.FormattingEnabled = true;
            this.lbxMsg.ItemHeight = 12;
            this.lbxMsg.Location = new System.Drawing.Point(0, 429);
            this.lbxMsg.Name = "lbxMsg";
            this.lbxMsg.Size = new System.Drawing.Size(916, 64);
            this.lbxMsg.TabIndex = 12;
            // 
            // mnuItmRun
            // 
            this.mnuItmRun.Index = 0;
            this.mnuItmRun.Text = "运行窗体(&R)";
            // 
            // mnuItmCascade
            // 
            this.mnuItmCascade.Index = 0;
            this.mnuItmCascade.Text = "层叠窗口";
            this.mnuItmCascade.Click += new System.EventHandler(this.mnuItmCascade_Click);
            // 
            // mnuItmTileHorizontal
            // 
            this.mnuItmTileHorizontal.Index = 1;
            this.mnuItmTileHorizontal.Text = "横向平铺窗口";
            this.mnuItmTileHorizontal.Click += new System.EventHandler(this.mnuItmTileHorizontal_Click);
            // 
            // mnuItmTileVertical
            // 
            this.mnuItmTileVertical.Index = 2;
            this.mnuItmTileVertical.Text = "纵向平铺窗口";
            this.mnuItmTileVertical.Click += new System.EventHandler(this.mnuItmTileVertical_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 3;
            this.menuItem1.Text = "-";
            // 
            // mnuItemWindow
            // 
            this.mnuItemWindow.Index = 1;
            this.mnuItemWindow.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuItmCascade,
            this.mnuItmTileHorizontal,
            this.mnuItmTileVertical,
            this.menuItem1});
            this.mnuItemWindow.Text = "窗口(&W)";
            // 
            // mnuItmAbout
            // 
            this.mnuItmAbout.Index = 0;
            this.mnuItmAbout.Shortcut = System.Windows.Forms.Shortcut.F1;
            this.mnuItmAbout.Text = "关于(&A)";
            this.mnuItmAbout.Click += new System.EventHandler(this.mnuItmAbout_Click);
            // 
            // mnuItmHelp
            // 
            this.mnuItmHelp.Index = 2;
            this.mnuItmHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuItmAbout});
            this.mnuItmHelp.Text = "帮助(&H)";
            // 
            // mnuMain
            // 
            this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuItmRun,
            this.mnuItemWindow,
            this.mnuItmHelp,
            this.menuItem2});
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 3;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuItmLogoff,
            this.mnuItmExit});
            this.menuItem2.Text = "系统(&S)";
            // 
            // mnuItmLogoff
            // 
            this.mnuItmLogoff.Index = 0;
            this.mnuItmLogoff.Text = "注销(&C)";
            this.mnuItmLogoff.Click += new System.EventHandler(this.mnuItmLogoff_Click);
            // 
            // mnuItmExit
            // 
            this.mnuItmExit.Index = 1;
            this.mnuItmExit.Text = "退出(&E)";
            this.mnuItmExit.Click += new System.EventHandler(this.mnuItmExit_Click);
            // 
            // FormMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(916, 515);
            this.Controls.Add(this.lbxMsg);
            this.Controls.Add(this.staBarMain);
            this.IsMdiContainer = true;
            this.Menu = this.mnuMain;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "动态加载窗体";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusBar staBarMain;
        private System.Windows.Forms.StatusBarPanel pnlInfo;
        private System.Windows.Forms.StatusBarPanel pnlNum;
        private System.Windows.Forms.ListBox lbxMsg;
        private System.Windows.Forms.MenuItem mnuItmRun;
        private System.Windows.Forms.MenuItem mnuItmCascade;
        private System.Windows.Forms.MenuItem mnuItmTileHorizontal;
        private System.Windows.Forms.MenuItem mnuItmTileVertical;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem mnuItemWindow;
        private System.Windows.Forms.MenuItem mnuItmAbout;
        private System.Windows.Forms.MenuItem mnuItmHelp;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem mnuItmLogoff;
        private System.Windows.Forms.MenuItem mnuItmExit;
        public System.Windows.Forms.MainMenu mnuMain;
    }
}