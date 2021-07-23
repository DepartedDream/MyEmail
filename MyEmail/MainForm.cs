using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyEmail
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        private void sendBtn_Click(object sender, EventArgs e)
        {
            Program.NowFormType = typeof(SendForm);
            this.Dispose();
        }
        private void receiveBtn_Click(object sender, EventArgs e)
        {
            Program.NowFormType = typeof(ReceiveForm);
            this.Dispose();
        }

        private void setBtn_Click(object sender, EventArgs e)
        {
            Program.NowFormType = typeof(Pop3AddressTb);
            this.Dispose();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.NowFormType = null;
            this.Dispose();
        }

    }
}
