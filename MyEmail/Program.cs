using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace MyEmail
{
    static class Program
    {
        public static Type NowFormType { get; set; }
        public static string SmtpAddress { get; set; }
        public static string Pop3Address { get; set; }
        public static string EmailAddress { get; set; }
        public static string EmailPwd { get; set; }
        private static string key = "17412911";
        private static string iv = "1sfrgd;80jkasd43rh'0-9k5t6ikj9pas[o789l7y8lo76y8ok";
        private static string setFilePath = $"{AppDomain.CurrentDomain.BaseDirectory}Setting";

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ReadSet();
            NowFormType = typeof(MainForm);
            while (true)
            {
                if (NowFormType != null)
                {
                    Application.Run((Form)Activator.CreateInstance(NowFormType));
                }
                else
                {
                    break;
                }
            }
            SaveSet();
            Application.Exit();
        }

        private static void ReadSet()
        {
            if (File.Exists(setFilePath))
            {
                FileInfo setFile = new FileInfo(setFilePath);
                StreamReader sr = setFile.OpenText();
                SmtpAddress=DESDecrypt(sr.ReadLine());
                Pop3Address = DESDecrypt(sr.ReadLine());
                EmailAddress = DESDecrypt(sr.ReadLine());
                EmailPwd = DESDecrypt(sr.ReadLine());
                sr.Dispose();
            }
        }

        private static void SaveSet()
        {
            if (!File.Exists(setFilePath))
            {
                File.Create(setFilePath).Close();
            }
            FileInfo setFile = new FileInfo(setFilePath);
            StreamWriter sw = setFile.CreateText();
            sw.WriteLine(DESEncrypt(SmtpAddress));
            sw.WriteLine(DESEncrypt(Pop3Address));
            sw.WriteLine(DESEncrypt(EmailAddress));
            sw.WriteLine(DESEncrypt(EmailPwd));
            sw.Dispose();
        }

        private static string DESEncrypt(string data)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(iv);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }

        private static string DESDecrypt(string data)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(iv);
            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(data);
            }
            catch
            {
                return null;
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            return sr.ReadToEnd();
        }

    }
}