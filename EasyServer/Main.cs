using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyServer
{
    public partial class Main : Form
    {
        [DllImport("user32.dll", EntryPoint = "SetParent")]
        public static extern int SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        void button1_Click(object sender, EventArgs e)
        {
            var cmd = Process.Start("cmd");
            SpinWait.SpinUntil(() => cmd.MainWindowHandle != (IntPtr)0);
            SetParent(cmd.MainWindowHandle, Handle);
        }

        public Main()
        {
            InitializeComponent();
        }
    }
}
