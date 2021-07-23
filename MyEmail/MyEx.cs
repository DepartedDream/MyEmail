using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEmail
{
    public class MyEx
    {
        public static void SaveException(Exception exception)
        {
            FileInfo fileInfo = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "\\Log.txt");
            StreamWriter streamWriter = fileInfo.AppendText();
            try 
            {
                Exception innerException = GetInnerException(exception);
                streamWriter.WriteLine(DateTime.Now.ToString());
                streamWriter.WriteLine(innerException.Message);
                streamWriter.WriteLine(innerException.StackTrace);
                streamWriter.WriteLine();
                streamWriter.Close();
                streamWriter.Dispose();
            }
            finally
            {
                streamWriter.Dispose();
            }
        }

        private static Exception GetInnerException(Exception exception)
        {
            if (exception.InnerException != null)
            {
                return GetInnerException(exception.InnerException);
            }
            else
            {
                return exception;
            }
        }

    }
}
