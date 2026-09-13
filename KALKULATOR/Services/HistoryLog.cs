using System;
using System.IO;
using System.Windows;

namespace KALKULATOR.Services
{
    public class HistoryLog
    {
        private string logPath = "calculator_log.txt";
        

        public void SaveToLog(string newtext)
        {
            using (StreamWriter writer = File.AppendText(logPath))
            {
                writer.WriteLine($"{DateTime.Now}: {newtext}");
            }
        }

        public string ReadLog()
        {
            if (File.Exists(logPath))
            {
                return File.ReadAllText(logPath);
            }
            return null;
        }

        public bool ClearLogFile()
        {
            if (File.Exists(logPath))
            {
                File.Delete(logPath);
                return true;
            }
            return false;
        }

    }
}
