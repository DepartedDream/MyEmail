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
    public partial class Pop3AddressTb : Form
    {
        public Pop3AddressTb()
        {
            InitializeComponent();
            smtpTb.Text = Program.SmtpAddress;
            pop3Tb.Text= Program.Pop3Address;
            emailTb.Text= Program.EmailAddress;
            pwdTb.Text= Program.EmailPwd;
        }

        private void SetForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.NowFormType = null;
            this.Dispose();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Program.SmtpAddress = smtpTb.Text;
            Program.Pop3Address = pop3Tb.Text;
            Program.EmailAddress = emailTb.Text;
            Program.EmailPwd = pwdTb.Text;
            Program.NowFormType = typeof(MainForm);
            this.Dispose();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Program.NowFormType = typeof(MainForm);
            this.Dispose();
        }
    }
}
