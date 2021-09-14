using System;
using System.IO;

namespace IW4DumpHelperGUI.Core.Logging
{
    public class Logger
    {
        public bool ShowInConsole { set; get; } = false;
        public bool BackupFullLogs { set; get; } = true;

        private StreamWriter LogWriter;
        private string LogFilePath;
        private string LogFileBackupDirectory;

        public Logger(bool showInConsole = false, bool backupFullLogs = true)
        {
            ShowInConsole = showInConsole;
            BackupFullLogs = backupFullLogs;

            //Create Logs folder if needed
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "LOGS")))
            {
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "LOGS"));
            }

            //Create Logs Backup folder if needed
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "LOGS", "BACKUPS")))
            {
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "LOGS", "BACKUPS"));
            }

            //Paths
            LogFilePath = Path.Combine(Environment.CurrentDirectory, "LOGS", "LOG.log");
            LogFileBackupDirectory = Path.Combine(Environment.CurrentDirectory, "LOGS", "BACKUPS");

            //Check for backup
            BackupLogFileIfNeeded(LogFilePath, LogFileBackupDirectory);

            //Create Writer
            LogWriter = new StreamWriter(LogFilePath, true);

            Print("----------------- APP INIT -----------------");
        }

        //Print a log msg
        public void Print(string MSG, LogTypes Type = LogTypes.INFO)
        {
            DateTime dateTime = DateTime.Now;
            if (MSG != "LOGFUNC__EMPTY__LOGFUNC")
            {
                if (Type == LogTypes.INFO)
                {
                    if (ShowInConsole)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(Type.ToString() + " --- " + MSG);
                    }
                    LogWriter.WriteLine("[" + dateTime + "] - " + Type.ToString() + " --- " + MSG);
                    LogWriter.Flush();
                }
                else if (Type == LogTypes.WARNING)
                {
                    if (ShowInConsole)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(Type.ToString() + " --- " + MSG);
                    }
                    LogWriter.WriteLine("[" + dateTime + "] - " + Type.ToString() + " --- " + MSG);
                    LogWriter.Flush();
                }
                else if (Type == LogTypes.ERROR)
                {
                    if (ShowInConsole)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(Type.ToString() + " --- " + MSG);
                    }
                    LogWriter.WriteLine("[" + dateTime + "] - " + Type.ToString() + " --- " + MSG);
                    LogWriter.Flush();
                }
                else
                {
                    if (ShowInConsole)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("UNKNOWN TYPE --- " + MSG);
                    }
                    LogWriter.WriteLine("[" + dateTime + "] - " + "UNKNOWN TYPE --- " + MSG);
                    LogWriter.Flush();
                }
            }
            else
            {
                LogWriter.WriteLine("");
                LogWriter.Flush();
            }
        }

        //Check if backup is needed
        //if needed rename + copy log file into the backup folder otherwise do nothing
        private void BackupLogFileIfNeeded(string file, string backUpDir)
        {
            if (File.Exists(file))
            {
                if (GetFileSize(file) >= 800000)//800kb
                {
                    if (BackupFullLogs)
                    {
                        DateTime dateTime = DateTime.Now;
                        int directorySize = Directory.GetFiles(backUpDir).Length;
                        string backUpStartName = "LOG_BACKUP_" + directorySize + "[" + dateTime + "]";
                        File.Copy(file, Path.Combine(backUpDir, backUpStartName + ".txt"));
                    }
                    File.Delete(file);
                    if (ShowInConsole)
                    {
                        Console.WriteLine("LOG Backup Done!");
                    }
                }
            }
        }

        //Get file size in byte
        private long GetFileSize(string filename)
        {
            FileInfo file = new FileInfo(filename);
            return file.Length;
        }
    }
}
