using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Xero.BankFeeds.Helpers
{
    public class LogHelper
    {
        //log file
        private static string _logFileName = string.Format("{0:yyyymmddhhmmss}", DateTime.Now);
        private static StreamWriter _streamw = null;

        //Create a file to store log information
        //Create a method to write text in a a log file
        public static void CreateLogFile()
        {
            string dir = @"C:\Temp\Test Reports\TestAutomationLogs\";
            if (Directory.Exists(dir))
            {
                _streamw = File.AppendText(dir + _logFileName + ".log");
            }
            else
            {
                Directory.CreateDirectory(dir);
                _streamw = File.AppendText(dir + _logFileName + ".log");
            }
        }

        //Create a method which can write the text in the log file
        public static void Write(string logMessage)
        {
            _streamw.Write("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _streamw.WriteLine("    {0}", logMessage);
            _streamw.Flush();
        }
    }
}
