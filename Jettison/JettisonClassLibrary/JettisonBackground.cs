using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.IO;

namespace JettisonClassLibrary
{
    public class JettisonBackground
    {
        public static DataHandler dh = DataHandler.GetInstance();
        public static Dictionary<string, bool> settings = dh.GetSettings();
        public static System.Windows.Forms.NotifyIcon trayIcon = new System.Windows.Forms.NotifyIcon();
        public static bool PowerOn = true;

        public static void CheckJettisons()
        {
            //DataHandler dh = DataHandler.getInstance();
            List<Jettison> all = dh.GetAllJettisons();
            while (all != null && all.Count > 0 && PowerOn)
            {
                foreach (Jettison j in all.ToList())
                {
                    if (Directory.Exists(j.Directory))
                    {

                        string[] dirs = Directory.GetDirectories(j.Directory);
                        string[] files = Directory.GetFiles(j.Directory, "*.*", SearchOption.AllDirectories);

                        // first, check and remove files in all directories if necessary
                        foreach (string file in files)
                        {
                            CheckFile(j, file);
                        }

                        // next, clean up empty sub directories
                        CleanDirectory(j.Directory);
                    }
                    Thread.Sleep(1000);
                }
            }
        }

        private static void CheckFile(Jettison j, string file)
        {
            DateTime fileDate = File.GetLastAccessTime(file);
            if (j.JettisonFiles == null)
            {
                j.JettisonFiles = new List<JettisonFile>();
            }
            JettisonFile jFile = j.JettisonFiles.Where(x => x.FullPath == file).FirstOrDefault();
            if (jFile == null)
            {
                jFile = dh.AddFileToJettison(j, file);
            }
            fileDate = jFile.DropTime;
            DateTime now = DateTime.Now;
            TimeSpan span = now.Subtract(fileDate);
            bool delete = !j.Recycle;

            // 24 hours
            if (j.MaxLife == 1)
            {
                if (span.TotalHours >= 24)
                {
                    DisposeFile(j, file, delete);
                }
            }

            // 48 hours
            else if (j.MaxLife == 2)
            {
                if (span.TotalHours >= 48)
                {
                    DisposeFile(j, file, delete);
                }
            }

            // 72 hours
            else if (j.MaxLife == 3)
            {
                if (span.TotalHours >= 72)
                {
                    DisposeFile(j, file, delete);
                }
            }

            // custom
            else if (j.MaxLife == 4)
            {

                // seconds
                if (j.CustomLifeDuration == 1)
                {
                    if (span.TotalSeconds >= j.CustomLife)
                    {
                        DisposeFile(j, file, delete);
                    }
                }

                // minutes
                else if (j.CustomLifeDuration == 2)
                {
                    if (span.TotalMinutes >= j.CustomLife)
                    {
                        DisposeFile(j, file, delete);
                    }
                }

                // hours
                else if (j.CustomLifeDuration == 3)
                {
                    if (span.TotalHours >= j.CustomLife)
                    {
                        DisposeFile(j, file, delete);
                    }
                }
            }
        }

        private static void DisposeFile(Jettison j, string file, bool delete)
        {
            LogOperationType opType;
            if (delete)
            {
                try
                {
                    File.Delete(file);
                    opType = LogOperationType.Delete;
                }
                catch (Exception)
                {
                    opType = LogOperationType.DeleteFail;
                }
            }
            else
            {
                try
                {
                    FileOperationAPIWrapper.MoveToRecycleBin(file);
                    opType = LogOperationType.MoveToRecycleBin;
                }
                catch (Exception)
                {
                    opType = LogOperationType.MoveToRecycleBinFail;
                }
            }
            dh.RemoveFileFromJettison(j, file);

            if (settings["LogHistory"] == true)
            {
				JFLog.Log(opType, file);
            }

            if (settings["DisplayAlerts"] == true)
            {
                trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
                trayIcon.BalloonTipTitle = "Jettison";
                trayIcon.BalloonTipText = file + " was deleted";
                trayIcon.ShowBalloonTip(2000);
            }
        }

        private static void CleanDirectory(string startLocation)
        {
            // http://stackoverflow.com/questions/2811509/c-sharp-remove-all-empty-subdirectories
            foreach (var directory in System.IO.Directory.GetDirectories(startLocation))
            {
                CleanDirectory(directory);
                if (System.IO.Directory.GetFiles(directory).Length == 0 && System.IO.Directory.GetDirectories(directory).Length == 0)
                {
                    Directory.Delete(directory, false);
                }
            }
        }
    }
}
