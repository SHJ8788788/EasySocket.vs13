using EasySocket.vs13.Serializers;
using EasySocket.vs13.Telegram.Easy;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MM00
{
    public partial class FormMM00A1 : Form
    {
        private int code = 0;
        private Action<string> MsgHandle;

        public FormMM00A1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Client.Instance.TimeOut = TimeSpan.FromSeconds(30);
            ////连接时采用同步方式，等待服务端返回结果，会引起阻塞，（异步方式无法判断连接状态，不采用）
            //Client.Instance.Async = false;
            //Client.Instance.Serializer = new ProtoBufSerializer();
            ////委托绑定UI委托，在调用时可通过判断调用是否在同一线程内
            ////不在同一线程可使用控件的Invoke方法调用MsgHandle
            //Client.Instance.MsgHandle = MsgHandle
            //                          = AddMsg;
        }

        #region Event
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (EasyTcpClient.Instance.Connect("127.0.0.1", 5555))
            {

            }
            else
            {
                MessageBox.Show("服务器无法连接");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            EasyTcpClient.Instance.Stop();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (EasyTcpClient.Instance.IsConnected==true)
            {
                Login();
            }
            else
            {
                if (EasyTcpClient.Instance.Connect("127.0.0.1", 5555))
                {
                    Login();
                }
                else
                {
                    MessageBox.Show("服务器无法连接");
                }
            }
        }

        private void btnLogoff_Click(object sender, EventArgs e)
        {

            Logoff();

        }

        private async void btnGetVersion_Click(object sender, EventArgs e)
        {
            try
            {
                var version = await ClientProxy.GetVersion();
                tbGetVersion.Text = version;
            }
            catch (Exception ee)
            {
                this.AddMsg(ee.Message.ToString());
            }
        }

        private async void btnGetMessage_Click(object sender, EventArgs e)
        {
            //EasyTcpClient.Instance.TimeOut = TimeSpan.FromSeconds(30);
            ////连接时采用同步方式，等待服务端返回结果，会引起阻塞，（异步方式无法判断连接状态，不采用）
            //EasyTcpClient.Instance.Async = false;
            //EasyTcpClient.Instance.Serializer = new ProtoBufSerializer();
            ////委托绑定UI委托，在调用时可通过判断调用是否在同一线程内
            ////不在同一线程可使用控件的Invoke方法调用MsgHandle
            //EasyTcpClient.Instance.MsgHandle = MsgHandle
            //                          = AddMsg;
            //if (EasyTcpClient.Instance.Connect("127.0.0.1", 5555))
            //{

            //}
            //else
            //{
            //    MessageBox.Show("服务器无法连接");
            //}   

            try
            {
                code += 1;             
                 //var sdf  = c.InvokeApi<String>("GetMessage", "史哥睡觉--第" + code + "次");               
                //var result = await Client.Instance.GetMessage(code);
                var result = await ClientProxy.GetMessage(code);
                tbGetMessage.Text = result;                
                Console.WriteLine(DateTime.Now.ToString() + "  " + result);
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
                code += 1;
                var result = await ClientProxy.GetMessage10s(code);
                tbGetMessage10s.Text = result;
                Console.WriteLine(DateTime.Now.ToString() + "  " + result);
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
                ClientProxy.GetVoidMessage(code);
            }
            catch (Exception ee)
            {
                this.AddMsg(ee.Message.ToString());
            }

        }


        private void btn100000s_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < Convert.ToInt32(tbnum.Text.ToString()); i++)
            //{
            //    if (Client.Instance.IsConnected)
            //    {
            //        switch (cbType.Text)
            //        {
            //            case "打印返回信息":
            //                btnGetMessage_Click(sender, e);
            //                break;
            //            case "打印返回信息10s":
            //                btnGetMessage10s_Click(sender, e);
            //                break;
            //            case "获取版本号":
            //                btnGetVersion_Click(sender, e);
            //                break;
            //            default:
            //                break;
            //        }
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
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
                var result = await ClientProxy.Login(user, false);
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
                var result = await ClientProxy.Logoff(user, false);
                this.AddMsg(result.Message);
            }
            catch (Exception ee)
            {
                this.AddMsg(ee.Message.ToString());
            }
        }
        #endregion

        private async void btnGetValue_Click(object sender, EventArgs e)
        {
            List<string> tagNames = new List<string> { txtTagName1.Text, txtTagName2.Text, txtTagName3.Text };
            var result = await ClientProxy.GetTags(tagNames);
            txtTagValue1.Text = result[0].TagValue;
            txtTagValue2.Text = result[1].TagValue;
            txtTagValue3.Text = result[2].TagValue;
        }
    }
}
