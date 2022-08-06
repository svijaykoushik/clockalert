using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ClockAlert.Modules
{
    internal enum LogLevel
    {
        Info,
        Warn,
        Error,
        Fatal
    }
    internal static class Logger
    {
        private static readonly string path;
        private static readonly string rollOverPath;
        static Logger()
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            char sep = Path.DirectorySeparatorChar;
            string vendor = Application.CompanyName.ToLower();
            vendor = Regex.Replace(vendor, @"\(.*\)", "").Trim();
            vendor = Regex.Replace(vendor, @"[\s,]", "-");
            string appName = Application.ProductName.ToLower();
            appName = Regex.Replace(appName, @"[\s,]", "-");
            string ext = ".log";
            path = appData + sep + vendor + sep + appName + sep + appName + ext;
            string dirPath = Path.GetDirectoryName(path);
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            string rolledLogName = $"{appName}.old{ext}";
            rollOverPath = Path.Combine(dirPath, rolledLogName);
            System.Diagnostics.Debug.WriteLine(path);

        }

        private static long GetSizeInMegaBytes()
        {
            if (File.Exists(path) == false)
            {
                return 0;
            }
            long size;
            long bytes;
            bytes = new FileInfo(path).Length;
            size = bytes / 1048576;
            return size;
        }

        private static bool ShouldRollOver()
        {
            long size = GetSizeInMegaBytes();
            int maxSize = Properties.Settings.Default.MaxLogSizeInMegaBytes;
            if (size >= maxSize)
            {
                return true;
            }
            return false;
        }

        private static void RollOver()
        {
            if (File.Exists(rollOverPath))
            {
                File.Delete(rollOverPath);
            }
            File.Move(path, rollOverPath);
        }

        public static async void LogAsync(LogLevel logLevel, string message)
        {
            bool hasRolledOver = false;
            if (ShouldRollOver())
            {
                RollOver();
                hasRolledOver = true;
            }
            string user = Environment.UserName.ToLower();
            user = Regex.Replace(user, @"[\s]", "-");
            string appId = Properties.Settings.Default.AppId.ToString();
            StreamWriter streamWriter = new StreamWriter(path, true);
            if (hasRolledOver)
            {
                string appName = Application.ProductName.ToLower();
                appName = Regex.Replace(appName, @"[\s,]", "-");
                string rollOverMessage = $"{LogLevel.Warn} {appId} {appName} [{DateTime.Now:yyyy-MM-dd HH:mm:ss zzz}] \"Rolled over\"";
                await streamWriter.WriteLineAsync(rollOverMessage);
            }
            string logItem = $"{logLevel} {appId} {user} [{DateTime.Now:yyyy-MM-dd HH:mm:ss zzz}] \"{message}\"";
            await streamWriter.WriteLineAsync(logItem);
            streamWriter.Close();
        }
    }
}
