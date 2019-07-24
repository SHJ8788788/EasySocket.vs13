using EasySocket.vs13.Serializers;
using EasySocket.vs13.Telegram.Easy;
using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyClient
{
    public partial class FormMain : Form
    {
        private int formNum;
        private ArrayList formTypes = new ArrayList();
        private ArrayList formObjects = new ArrayList();
        private Action<string> MsgHandle;
        private Action CloseHandle;

        private UserInfo user=default(UserInfo);
        //登陆框是否打开，true：已打开false：未打开
        //防止登陆框重复打开
        private bool LoginDialogStatus = false;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Assembly assembly = null;
            string windowsPath = Path.Combine(Application.StartupPath, "Form");
            //string windowsPath = Application.StartupPath;
            foreach (string dllFile in Directory.GetFiles(windowsPath, "*.dll"))
            {
                string dllFileName = dllFile.Substring(dllFile.LastIndexOf("\\") + 1, (dllFile.LastIndexOf(".") - dllFile.LastIndexOf("\\") - 1)); //文件名
                //必须采用Assembly.Load才能使用全局已初始化的静态方法
                assembly = Assembly.Load(dllFileName);
                Type[] types = assembly.GetTypes().Where(p => p.BaseType == typeof(Form)).ToArray();
                foreach (Type t in types)
                {
                    this.formTypes.Add(t);
                    MenuItem item = this.mnuItmRun.MenuItems.Add(t.FullName);
                    item.Click += new EventHandler(menuItemNewItem_Click);
                }
            }
            EasyTcpClient.Instance.TimeOut = TimeSpan.FromSeconds(30);
            //连接时采用同步方式，等待服务端返回结果，会引起阻塞，（异步方式无法判断连接状态，不采用）
            EasyTcpClient.Instance.Async = false;
            //是否开启断线重连,(在网络异常的情况，将尝试重连),
            //客户端使用时不应开启，在使用OPC或通讯中间件时为了保证通讯正常，可开启
            EasyTcpClient.Instance.ReconnectEnable = false;
            //采用序列化方式
            EasyTcpClient.Instance.Serializer = new ProtoBufSerializer();
            //委托绑定UI委托，在调用时可通过判断调用是否在同一线程内
            //不在同一线程可使用控件的Invoke方法调用MsgHandle
            EasyTcpClient.Instance.MsgHandle = MsgHandle
                                      = AddMsg;
            //不在同一线程可使用控件的Invoke方法调用CloseHandle
            EasyTcpClient.Instance.CloseHandle = CloseHandle
                                      = LoginFormShowAfterReconnect;
            //if (EasyTcpClient.Instance.Connect("172.16.6.30", 5555))
            if (EasyTcpClient.Instance.Connect("172.22.197.45", 5555))
            {

            }
            else
            {
                MessageBox.Show("服务器无法连接");
            }

            LoginFormShow();
        }     

        private void menuItemNewItem_Click(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;

            Type t = (Type)(this.formTypes[item.Index]);

            Object obj = Activator.CreateInstance(t);
            this.formObjects.Add(obj);
            formNum += 1;

            t.InvokeMember("MdiParent", BindingFlags.SetProperty, null, obj, new object[] { this });
            t.InvokeMember("WindowState", BindingFlags.SetProperty, null, obj, new object[] { FormWindowState.Maximized });
            t.InvokeMember("Text", BindingFlags.SetProperty, null, obj, new object[] { t.FullName + "  窗体：" + formNum });
            t.InvokeMember("Show", BindingFlags.InvokeMethod, null, obj, new object[] { });

            ((Form)obj).Closing += new CancelEventHandler(FrmWindow_Closing);
            ((Form)obj).Activated += new EventHandler(FrmWindow_Activated);
            MenuItem menuItem = this.mnuItemWindow.MenuItems.Add(((Form)obj).Text);
            menuItem.Click += new EventHandler(menuItemWindow_Click);

            this.pnlNum.Text = "当前装载了" + this.formObjects.Count + "个窗体";
            this.pnlInfo.Text = "当前活动窗体：" + this.ActiveMdiChild.Text;
        }

        private void menuItemWindow_Click(object sender, System.EventArgs e)
        {
            MenuItem item = (MenuItem)sender;

            ((Form)(this.formObjects[item.Index - 4])).Activate();

            this.pnlNum.Text = "当前装载了" + this.formObjects.Count + "个窗体";
            this.pnlInfo.Text = "当前活动窗体：" + this.ActiveMdiChild.Text;
        }

        private void FrmWindow_Activated(object sender, System.EventArgs e)
        {
            this.pnlNum.Text = "当前装载了" + this.formObjects.Count + "个窗体";
            this.pnlInfo.Text = "当前活动窗体：" + this.ActiveMdiChild.Text;
        }

        private void FrmWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            for (int i = 0; i < this.formObjects.Count; i++)
            {
                if (((Form)this.formObjects[i]).Text == ((Form)sender).Text)
                {
                    this.formObjects.RemoveAt(i);
                    this.mnuItemWindow.MenuItems.RemoveAt(i + 4);

                    this.pnlNum.Text = "当前装载了" + this.formObjects.Count + "个窗体";
                    this.pnlInfo.Text = "当前活动窗体：" + this.ActiveMdiChild.Text;
                    break;
                }
            }
        }

        private void mnuItmCascade_Click(object sender, System.EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuItmTileHorizontal_Click(object sender, System.EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuItmTileVertical_Click(object sender, System.EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuItmAbout_Click(object sender, System.EventArgs e)
        {
            //new FrmAbout().ShowDialog(this);  
        }
        private void mnuItmLogoff_Click(object sender, EventArgs e)
        {
            Logoff();
        }

        /// <summary>
        /// 往listbox加一条项目
        /// </summary>
        /// <param name="msg"></param>
        private void AddMsg(string msg)
        {
            //查询控件的 InvokeRequired 属性。
            //如果 InvokeRequired 返回 true，则使用实际调用控件的委托来调用 Invoke。
            //如果 InvokeRequired 返回 false，则直接调用控件。
            if (this.lbxMsg.InvokeRequired)
            {
                // 加个委托显示msg,因为on系列都是在工作线程中调用的,ui不允许直接操作
                // 很帅的调自己
                this.lbxMsg.Invoke(MsgHandle, msg);
            }
            else
            {
                if (this.lbxMsg.Items.Count > 100)
                {
                    this.lbxMsg.Items.RemoveAt(0);
                }
                this.lbxMsg.Items.Add(msg);
                this.lbxMsg.TopIndex = this.lbxMsg.Items.Count - (int)(this.lbxMsg.Height / this.lbxMsg.ItemHeight);
            }
        }
        /// <summary>
        /// 断线后重连或注销后必须重新登陆
        /// </summary>
        private void LoginFormShowAfterReconnect()
        {            
            //查询控件的 InvokeRequired 属性。
            //如果 InvokeRequired 返回 true，则使用实际调用控件的委托来调用 Invoke。
            //如果 InvokeRequired 返回 false，则直接调用控件。
            if (this.InvokeRequired)
            {
                // 加个委托显示msg,因为on系列都是在工作线程中调用的,ui不允许直接操作
                // 很帅的调自己
                this.Invoke(CloseHandle);
            }
            else
            {

                LoginFormShow(user.Account);
            }
        }
        /// <summary>
        /// 登陆框显示
        /// </summary>
        private void LoginFormShow(string userName = "")
        {
            //当前已打开窗体了，直接退出
            if (LoginDialogStatus == true)
            {
                return;
            }
            FormLogin lon =userName ==""? new FormLogin():new FormLogin(userName);
            lon.StartPosition = FormStartPosition.CenterScreen;
            LoginDialogStatus = true;
            lon.ShowDialog();
            LoginDialogStatus = false;
            if (lon.DialogResult == DialogResult.OK)
            {
                var userNameFromDialog = lon.UserName;
                var passwordFromDialog = lon.Password;
                Login(userNameFromDialog, passwordFromDialog);
            }
            else
            {
                this.Close();
            }
        }

        private async void Login(string userNameFromDialog, string passwordFromDialog)
        {
                try
                {
                    //Random rm = new Random();
                    //string ra = rm.Next(1000).ToString();
                    //passwordFromDialog += ra;
                    //this.tbUser.Text = this.tbUser.Text.Substring(0, 5) + ra;
                    user = new UserInfo { Account = userNameFromDialog, Password = passwordFromDialog };

                    switch (EasyTcpClient.Instance.IsConnected)
                    {
                        case true:
                            var result = await ClientProxy.Login(user, false);
                            this.AddMsg(result.Message);
                            break;
                        case false:
                            if (EasyTcpClient.Instance.ReConnectAsync()==true)
                            {
                                Login(userNameFromDialog,passwordFromDialog);
                            }
                            else
                            {
                                MessageBox.Show("服务器无法连接");
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ee)
                {
                    this.AddMsg(ee.Message.ToString());
                }         
        }

        private async void Logoff()
        {
            //执行注销
            var result = await ClientProxy.Logoff(user, false);
            this.AddMsg(result.Message);
            //弹出登陆框
            LoginFormShowAfterReconnect();
        }

        private async void LogTest()
        {
           var  user2 = new UserInfo { Account = "testet", Password = "123123123123" };

             List<UserInfo> users = new List<UserInfo>();
             users.Add(user);
             users.Add(user2);
             try
             {
                 var result = await ClientProxy.LogTest(users, false);
                 this.AddMsg(result.Message);
             }
             catch (Exception ex)
             {                 
                 this.AddMsg(ex.Message);
             }
             
        }

        private async void Log2StringTest()
        {       
            List<string> users = new List<string>();
            users.Add("111111111111111");
            users.Add("222222222222222");
            var result = await ClientProxy.Log2StringTest(users, false);
            this.AddMsg(result.Message);
        }

        private void mnuItmExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogTest();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Log2StringTest();
        }
    }
}
