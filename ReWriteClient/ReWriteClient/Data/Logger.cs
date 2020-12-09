using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ReWriteClient.Data
{
    public class Logger
    {
        private static Logger instance;
        public static Logger Instance = instance ?? new Logger();

        private Logger()
        { }

        public static string FileName = "Log.txt";

        public void Error(string message, string origin)
        {
            using StreamWriter sw = File.AppendText(FileName);

            sw.WriteLine($"ERROR: [{DateTime.Now}] {origin} - {message}");
        }

        public void Info(string message, string origin)
        {
            using StreamWriter sw = File.AppendText(FileName);

            sw.WriteLine($"INFO: [{DateTime.Now}] {origin} - {message}");
        }
    }
}
