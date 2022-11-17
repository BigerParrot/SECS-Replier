using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SECSTry
{
    public static class Loger
    {
        private static string logPath = string.Empty;

        public static void WrireLog(string errString)
        {
            if (logPath == string.Empty)
            {
                logPath = string.Format(System.IO.Directory.GetCurrentDirectory() + "\\Logger");
            }
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            string filePath = string.Format("{0}\\{1}.txt",logPath, DateTime.Now.ToString("yyyyMMdd"));

            if (!File.Exists(filePath)) { File.Create(filePath); }

            using (StreamWriter wr = File.AppendText(filePath))
            {
                wr.Write(DateTime.Now.ToString("[HH:mm:ss]")+"\n");
                wr.Write(errString);
            }
        }
    }
}
