using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SECSTry
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += Application_ThreadException;
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SECSReplier());
            }
            catch
            {

            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception err = e.Exception as Exception;

            WriteException("未處理UI異常",err);
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception err = e.ExceptionObject as Exception;

            WriteException("未處理非UI執行緒異常", err);
        }

        static void WriteException(String type, Exception err)
        {
            try
            {
                string str = string.Empty;

                if (err != null)
                {
                    str = string.Format(type + "異常類型: {0}\n 異常消息: {1}\n 異常訊息: {2}\r\n", err.GetType().Name, err.Message, err.StackTrace + "/r/n" +err.ToString());

                }

                Loger.WrireLog(str);
            }
            catch(Exception ex)
            {
                Loger.WrireLog("紀錄異常" + ex.ToString());
            }
        }
    }
}
