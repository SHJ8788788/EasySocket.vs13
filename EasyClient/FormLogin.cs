using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyClient
{
    public partial class FormLogin : Form
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public FormLogin(string userName):this()
        {
            tbUserName.Text = userName;
            //Password = password;
        }

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserName = tbUserName.Text;
            Password = tbPassword.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        
    }
}
