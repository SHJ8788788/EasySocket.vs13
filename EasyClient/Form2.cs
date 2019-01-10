using EasySocket.vs13.Serializers;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyClient
{
    public partial class Form2 : Form
    {
        private int code = 0;
        private Action<string> MsgHandle;
        private List<ClientMoreTest> Clients = new List<ClientMoreTest>();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cbNum.SelectedIndex = 0;
        }

        #region Event
        private void btnStart_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < Convert.ToInt32(cbNum.Text); i++)
            {
                ClientMoreTest Client = new ClientMoreTest(i, 16);
                Client.TimeOut = TimeSpan.FromSeconds(30);
                //连接时采用同步方式，等待服务端返回结果，会引起阻塞，（异步方式无法判断连接状态，不采用）
                Client.Async = false;
                Client.Serializer = new ProtoBufSerializer();
                //委托绑定UI委托，在调用时可通过判断调用是否在同一线程内
                //不在同一线程可使用控件的Invoke方法调用MsgHandle
                Client.MsgHandle = MsgHandle
                                          = AddMsg;
                Clients.Add(Client);
            }  

            foreach (var Client in Clients)
            {

                if (Client.Connect("127.0.0.1", 5555))
                {

                }
                else
                {
                    MessageBox.Show("服务器无法连接");
                }
            }
          
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            foreach (var Client in Clients)
            {
                Client.Stop();
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            foreach (var Client in Clients)
            {
                if (Client.IsConnected == true)
                {
                    Login();
                }
                else
                {
                    if (Client.Connect("127.0.0.1", 5555))
                    {
                        Login();
                    }
                    else
                    {
                        MessageBox.Show("服务器无法连接");
                    }
                }
            }
        }

        private void btnLogoff_Click(object sender, EventArgs e)
        {
            foreach (var Client in Clients)
            {
                Logoff();
            }

        }

        private async void btnGetVersion_Click(object sender, EventArgs e)
        {
            foreach (var Client in Clients)
            {
                try
                {
                    var version = await Client.GetVersion();
                    tbGetVersion.Text = version;
                }
                catch (Exception ee)
                {
                    this.AddMsg(ee.Message.ToString());
                }
            }

        }

        private async void btnGetMessage_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var Client in Clients)
                {
                    code += 1;
                    var result = await Client.GetMessage(code);
                    tbGetMessage.Text = result;
                    Console.WriteLine(DateTime.Now.ToString() + "  " + result);
                }
            }
            catch (Exception ee)
            {
                this.AddMsg(ee.Message.ToString());
            }
        }

        private async void btnGetMessage10s_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var Client in Clients)
                {
                    code += 1;
                    var result = await Client.GetMessage10s(code);
                    tbGetMessage10s.Text = result;
                    Console.WriteLine(DateTime.Now.ToString() + "  " + result);
                }
            }
            catch (Exception ee)
            {
                this.AddMsg(ee.Message.ToString());
            }
        }

        private void btnVoidSetMessage_Click(object sender, EventArgs e)
        {
            try
            {
                code += 1;
                Client.Instance.GetVoidMessage(code);
            }
            catch (Exception ee)
            {
                this.AddMsg(ee.Message.ToString());
            }

        }


        private void btn100000s_Click(object sender, EventArgs e)
        {
            foreach (var Client in Clients)
            {
                for (int i = 0; i < Convert.ToInt32(tbnum.Text.ToString()); i++)
                {
                    if (Client.IsConnected)
                    {
                        switch (cbType.Text)
                        {
                            case "打印返回信息":
                                btnGetMessage_Click(sender, e);
                                break;
                            case "打印返回信息10s":
                                btnGetMessage10s_Click(sender, e);
                                break;
                            case "获取版本号":
                                btnGetVersion_Click(sender, e);
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            code = 0;
        }
        #endregion

        #region Func
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

        private async void Login()
        {
            try
            {
                Random rm = new Random();
                string ra = rm.Next(1000).ToString();
                this.tbUser.Text = this.tbUser.Text.Substring(0, 5) + ra;
                var user = new UserInfo { Account = this.tbUser.Text, Password = this.tbPassword.Text };
                var result = await Client.Instance.Login(user, false);
                this.AddMsg(result.Message);
            }
            catch (Exception ee)
            {
                this.AddMsg(ee.Message.ToString());
            }
        }

        private async void Logoff()
        {
            try
            {
                var user = new UserInfo { Account = this.tbUser.Text, Password = this.tbPassword.Text };
                var result = await Client.Instance.Logoff(user, false);
                this.AddMsg(result.Message);
            }
            catch (Exception ee)
            {
                this.AddMsg(ee.Message.ToString());
            }
        }
        #endregion
    }
}
