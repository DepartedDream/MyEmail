using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEmail
{
    public class Email
    {
        public int EmailId { get; set; }
        public string EmailSubject { get; set; }
        public string EmailDate { get; set; }
        public string EmailSender { get; set; }
        public string EmailReceiver { get; set; }
        public string EmailContent { get; set;}

        public Email(int emailId,string emailSubject, string emailDate, string emailSender, string emailReceiver,string emailContent)
        {
            EmailId = emailId;
            EmailSubject = emailSubject;
            EmailDate = emailDate;
            EmailSender = emailSender;
            EmailReceiver = emailReceiver;
            EmailContent = emailContent;
        }
    }
}