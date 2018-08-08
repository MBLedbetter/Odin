using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OdinModels
{
    public class ErrorLog
    {
         static string folderName = @"C:\Users\" + Environment.UserName + @"\Documents\Odin_Log\";
        // static string folderName = @"\\abe\ClickOnce\Odin\resources\ErrorLog\" + Environment.UserName + @"\";
        // static string path = folderName + @"\ErrorLog.txt";

        #region Methods

        private static string GetFileName()
        {
            string fileName = folderName;
            fileName += "Odin_Error.txt";
            return fileName;
        }

        public static void CreateFolder()
        {
            if (!(Directory.Exists(folderName)))
            {
                System.IO.Directory.CreateDirectory(folderName);

            }
            if (!(File.Exists(GetFileName())))
            {
                using (StreamWriter sw = File.CreateText(GetFileName()))
                {
                    sw.WriteLine("Odin Error Log");
                }
            }
        }
        public static void LogError(string message, string detail)
        {
            string fileName = GetFileName();
            if (!string.IsNullOrEmpty(message))
            {
                string notification = "ERROR: " + message;
                notification += "\r\n";
                notification += "====================";
                notification += "\r\n";
                notification += detail;
                MessageBox.Show(notification);
            }
            if (!(File.Exists(fileName)))
            {
                File.CreateText(fileName);
            }
            using (StreamWriter w = File.AppendText(fileName))
            {
                Log(detail, w);
            }
            using (StreamReader r = File.OpenText(fileName))
            {
                DumpLog(r);
            }
        }

        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            w.WriteLine("{0}", logMessage);
            w.WriteLine("-------------------------------");
        }
        public static void DumpLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }

        #endregion // Methods
    }
}
