using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyEmail
{
    public partial class ReceiveForm : Form
    {
        private StreamWriter streamWriter;
        private StreamReader streamReader;
        private TcpClient tcpClient;
        private NetworkStream networkStream;
        private List<Email> emailList;
        private Thread initialEmailListThread;

        public ReceiveForm()
        {
            InitializeComponent();
            emailList = new List<Email>();
            TextBox.CheckForIllegalCrossThreadCalls = false;
        }

        private void ReceiveForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.NowFormType = null;
            DisposeAll();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Program.NowFormType = typeof(MainForm);
            DisposeAll();
        }

        private void ReceiveForm_Load(object sender, EventArgs e)
        {
            try
            {
                initialEmailListThread = new Thread(()=> 
                {
                    ConnectServer();
                    LoginServer();
                    GetEmailList();
                });
                initialEmailListThread.Start();
            }
            catch (Exception exception)
            {
                MyEx.SaveException(exception); ;
                this.Text = exception.Message;
            }
        }

        private void emailListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string emailItemText= ((ListBox)sender).Text;
            string emailIdPattern = @"\d+\u0020";
            int emailId = Convert.ToInt32(Regex.Matches(emailItemText, emailIdPattern)[0].Value);
            Email email = emailList.Find((Email pEmail) => emailId == pEmail.EmailId);
            infoLabel.Text = email.EmailSubject;
            emailWebBrowser.DocumentText = email.EmailContent;
            dateLb.Text = email.EmailDate;
            receiverLb.Text = email.EmailReceiver;
        }

        private void ConnectServer()
        {
            while (true) 
            {
                infoLabel.Text = "正在尝试连接到服务器";
                if (tcpClient != null) tcpClient.Dispose();
                if (networkStream != null) networkStream.Dispose();
                if (streamReader != null) streamReader.Dispose();
                if (streamWriter != null) streamWriter.Dispose();
                tcpClient = new TcpClient(Program.Pop3Address, 110);
                if (tcpClient == null) ConnectServer();
                networkStream = tcpClient.GetStream();
                streamReader = new StreamReader(networkStream, Encoding.UTF8);
                streamWriter = new StreamWriter(networkStream, Encoding.UTF8);
                streamWriter.AutoFlush = true;
                string response = streamReader.ReadLine();
                if (response != null&&response.StartsWith("+OK")) break;
            }
        }

        private void LoginServer() 
        {
            infoLabel.Text = "正在尝试登录到邮箱服务器";
            string response;
            while (true)
            {
                streamWriter.WriteLine($"USER {Program.EmailAddress}");
                response = streamReader.ReadLine();
                if (response != "" && response.StartsWith("+OK")) break;
            }
            while (true)
            {
                streamWriter.WriteLine($"PASS {Program.EmailPwd}");
                response = streamReader.ReadLine();
                if (response != "" && response.StartsWith("+OK")) break;
            }
        }

        private void QuitServer() 
        {
            streamWriter.WriteLine("QUIT");
            string response = streamReader.ReadLine();
        }

        private void GetEmailList()
        {
            infoLabel.Text = "正在读取邮件";
            int emailId = 1;
            while (true) 
            {
                infoLabel.Text = $"正在加载第{emailId}封邮件";
                string response;
                streamWriter.WriteLine($"RETR {emailId}");
                response = streamReader.ReadLine();
                if(response== "-ERR Message not exists") break;
                string emailStr = "";
                while (true)
                {
                    response = streamReader.ReadLine();
                    emailStr += $"{response}\n";
                    if (response == ".") break;
                }
                if (emailStr.StartsWith("Received: "))
                {
                    #region 获取标题
                    string subjectPattern = @"(?<=Subject:).+(?=\u003d\u003f)";
                    string subject = "";
                    if (Regex.Matches(emailStr, subjectPattern).Count != 0)
                    {
                        subject = Regex.Matches(emailStr, subjectPattern)[0].Value;
                    }
                    string encryptSubjectPattern = @"(?<=\u003d\u003f.+\u003f\u0042\u003f).+(?=\u003f\u003d)";
                    string encryptSubject = "";
                    if (Regex.Matches(emailStr, encryptSubjectPattern).Count != 0)
                    {
                        encryptSubject = Regex.Matches(emailStr, encryptSubjectPattern)[0].Value;
                    }
                    string subjectCharsetPattern = @"(?<=\u003d\u003f).+(?=\u003f\u0042\u003f)";
                    string subjectCharset = "";
                    if (Regex.Matches(emailStr, subjectCharsetPattern).Count != 0)
                    {
                        subjectCharset = Regex.Matches(emailStr, subjectCharsetPattern)[0].Value;
                    }
                    string emailSubject = "";
                    if (subject != "" && subjectCharset != "" && encryptSubject != "")
                    {
                        emailSubject =Encoding.GetEncoding(subjectCharset).GetString(Convert.FromBase64String(encryptSubject));
                    }
                    #endregion
                    #region 获取日期
                    string datePattern = @"(?<=Date\u003a\u0020)(Mon|Tue|Wed|Thu|Fri|Sat|Sun)\u002c\u0020\d{2}\u0020(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sept|Oct|Nov|Dec)\u0020\d{4}\u0020\d{2}\u003a\d{2}\u003a\d{2}\u0020(\u002b|\u002d)\d{4}";
                    string emailDate = Regex.Matches(emailStr, datePattern)[0].Value;
                    #endregion
                    #region 获取邮件发送者
                    string senderPattern = @"(?<=(From\u003a\u0020\u0022*))\w+(?=(\u0022*\u0020))";
                    string emailSender = Regex.Matches(emailStr, senderPattern)[0].Value;
                    #endregion
                    #region 获取邮件内容
                    string emailReceiver = Program.EmailAddress;
                    string contentPattern1 = @"(?<=Content-Type: text/html; charset=.+\nContent-Transfer-Encoding: .+\n)([\w\W]*)";
                    string contentPattern2 = @"(?<=Content-Transfer-Encoding: .+\nContent-Type: text/html; charset=.+\n)([\w\W]*)";
                    string emailContent = "";
                    MatchCollection matchCollection1 = Regex.Matches(emailStr, contentPattern1);
                    MatchCollection matchCollection2 = Regex.Matches(emailStr, contentPattern2);
                    if (matchCollection1.Count != 0)
                    {
                        emailContent = matchCollection1[0].Value;
                    }
                    else if (matchCollection2.Count != 0)
                    {
                        emailContent = matchCollection2[0].Value;
                    }
                    #endregion
                    emailList.Add(new Email(emailId, emailSubject, emailDate, emailSender, emailReceiver, emailContent));
                }
                emailId++;
            }
            emailList.Reverse();
            foreach (Email email in emailList)
            {
                emailListBox.Items.Add($"{email.EmailId} {email.EmailSubject}");
            }
            infoLabel.Text = "收信成功";
        }

        private void DisposeAll() 
        {
            QuitServer();
            initialEmailListThread.Abort();
            if (tcpClient != null) tcpClient.Dispose();
            if (networkStream != null) networkStream.Dispose();
            if (streamReader != null) streamReader.Dispose();
            if (streamWriter != null) streamWriter.Dispose();
            this.Dispose();
        }

    }
}