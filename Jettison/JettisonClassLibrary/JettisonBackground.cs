using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using static System.Diagnostics.Debug;
using System.Drawing;

namespace JettisonClassLibrary
{
    public class JettisonBackground
    {
        public static DataHandler dh = DataHandler.getInstance();
        public static Dictionary<string, bool> settings = dh.getSettings();
        public static System.Windows.Forms.NotifyIcon trayIcon = new System.Windows.Forms.NotifyIcon();
        public static bool PowerOn = true;

        public static void checkJettisons()
        {
            //DataHandler dh = DataHandler.getInstance();
            List<Jettison> all = dh.getAllJettisons();
            while (all != null && all.Count > 0 && PowerOn) {
                foreach (Jettison j in all.ToList()) {
                    if (Directory.Exists(j.Directory)) {

                        string[] dirs = Directory.GetDirectories(j.Directory);
                        string[] files = Directory.GetFiles(j.Directory, "*.*", SearchOption.AllDirectories);

                        // first, check and remove files in all directories if necessary
                        foreach (string file in files) {
                            checkFile(j, file);
                        }

                        // next, clean up empty sub directories
                        cleanDirectory(j.Directory);
                    }
                    Thread.Sleep(1000);
                }
            }
        }

        private static void checkFile(Jettison j, string file)
        {
            DateTime fileDate = File.GetLastAccessTime(file);
            if (j.JettisonFiles == null) {
                j.JettisonFiles = new List<JettisonFile>();
            }
            JettisonFile jFile = j.JettisonFiles.Where(x => x.FullPath == file).FirstOrDefault();
            if (jFile == null) {
                jFile = dh.addFileToJettison(j, file);
            }
            fileDate = jFile.DropTime;
            DateTime now = DateTime.Now;
            TimeSpan span = now.Subtract(fileDate);
            bool delete = !j.Recycle;

            // 24 hours
            if (j.MaxLife == 1) {
                if (span.TotalHours >= 24) {
                    disposeFile(j, file, delete);
                }
            }

            // 48 hours
            else if (j.MaxLife == 2) {
                if (span.TotalHours >= 48) {
                    disposeFile(j, file, delete);
                }
            }

            // 72 hours
            else if (j.MaxLife == 3) {
                if (span.TotalHours >= 72) {
                    disposeFile(j, file, delete);
                }
            }

            // custom
            else if (j.MaxLife == 4) {

                // seconds
                if (j.CustomLifeDuration == 1) {
                    if (span.TotalSeconds >= j.CustomLife) {
                        disposeFile(j, file, delete);
                    }
                }

                // minutes
                else if (j.CustomLifeDuration == 2) {
                    if (span.TotalMinutes >= j.CustomLife) {
                        disposeFile(j, file, delete);
                    }
                }

                // hours
                else if (j.CustomLifeDuration == 3) {
                    if (span.TotalHours >= j.CustomLife) {
                        disposeFile(j, file, delete);
                    }
                }
            }
        }

        private static void disposeFile(Jettison j, string file, bool delete)
        {
            string opType = "ERR";
            if (delete) {
                try {
                    File.Delete(file);
                    opType = "DEL";
                } catch (Exception) {
                    opType = "UNABLE TO DELETE FILE";
                }
            } else {
                try {
                    FileOperationAPIWrapper.MoveToRecycleBin(file);
                    opType = "REC";
                } catch (Exception) {
                    opType = "UNABLE TO RECYCLE FILE";
                }
            }
            dh.removeFileFromJettison(j, file);

            if (settings["LogHistory"] == true) {
				JFLog.Log(opType, file);
            }

            if (settings["DisplayAlerts"] == true) {
                trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
                trayIcon.BalloonTipTitle = "Jettison";
                trayIcon.BalloonTipText = file + " was deleted";
                trayIcon.ShowBalloonTip(2000);
            }
        }

        private static void cleanDirectory(string startLocation)
        {
            // http://stackoverflow.com/questions/2811509/c-sharp-remove-all-empty-subdirectories
            foreach (var directory in System.IO.Directory.GetDirectories(startLocation)) {
                cleanDirectory(directory);
                if (System.IO.Directory.GetFiles(directory).Length == 0 && System.IO.Directory.GetDirectories(directory).Length == 0) {
                    System.IO.Directory.Delete(directory, false);
                }
            }
        }
    }
}
