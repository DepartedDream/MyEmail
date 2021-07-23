using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyEmail
{
    public partial class SendForm : Form
    {
        public SendForm()
        {
            InitializeComponent();
        }

        private void SendForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.NowFormType = null;
            this.Dispose();
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            try 
            {
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = Program.SmtpAddress;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(Program.EmailAddress, Program.EmailPwd);
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From= new MailAddress(Program.EmailAddress);
                    mailMessage.To.Add(receiveAddressTb.Text);
                    mailMessage.IsBodyHtml = false;
                    mailMessage.Priority = MailPriority.Normal;
                    mailMessage.Subject = emailSubjectTb.Text;
                    mailMessage.Body = emailContentTb.Text;
                    smtpClient.Send(mailMessage);
                }
                MessageBox.Show("发送成功");
            }
            catch(SmtpException smtpError)
            {
                MessageBox.Show("发送失败:" + smtpError.StatusCode
                + "\n\n" + smtpError.Message
                + "\n\n" + smtpError.StackTrace);
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Program.NowFormType = typeof(MainForm);
            this.Dispose();
        }
    }
}
