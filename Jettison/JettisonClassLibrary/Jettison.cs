using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using static System.Diagnostics.Debug;
using System.Drawing;

namespace JettisonClassLibrary
{
    public class Jettison
    {
        public string Id { get; set; }
        public string Directory { get; set; }
        public int MaxLife { get; set; }
        public int CustomLife { get; set; }
        public int CustomLifeDuration { get; set; }
        public bool Recycle { get; set; }

        public static string getLifeText(Jettison jettison)
        {
            string returnString = string.Empty;
            if (jettison.MaxLife == 1) {
                returnString = "24 hours";
            } else if (jettison.MaxLife == 2) {
                returnString = "48 hours";
            } else if (jettison.MaxLife == 3) {
                returnString = "72 hours";
            } else if (jettison.MaxLife == 4) {
                string customLife = jettison.CustomLife.ToString();
                if (jettison.CustomLifeDuration == 1) {
                    customLife += " seconds";
                } else if (jettison.CustomLifeDuration == 2) {
                    customLife += " minutes";
                } else if (jettison.CustomLifeDuration == 3) {
                    customLife += " hours";
                }
                returnString = customLife;
            }
            return returnString;
        }

        public static void checkJettisons()
        {
            DataHandler dh = DataHandler.getInstance();
            List<Jettison> all = dh.getAllJettisons();
            while (all != null && all.Count > 0) {
                foreach (Jettison j in all.ToList()) {
                    if (System.IO.Directory.Exists(j.Directory)) {

                        string[] dirs = System.IO.Directory.GetDirectories(j.Directory);
                        string[] files = System.IO.Directory.GetFiles(j.Directory, "*.*", SearchOption.AllDirectories);

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
            DateTime fileDate = File.GetCreationTime(file);
            DateTime now = DateTime.Now;
            TimeSpan span = now.Subtract(fileDate);
            bool delete = j.Recycle;

            // 24 hours
            if (j.MaxLife == 1) {
                if (span.TotalHours >= 24) {
                    disposeFile(file, delete);
                }
            }

            // 48 hours
            else if (j.MaxLife == 2) {
                if (span.TotalHours >= 48) {
                    disposeFile(file, delete);
                }
            }

            // 72 hours
            else if (j.MaxLife == 3) {
                if (span.TotalHours >= 72) {
                    disposeFile(file, delete);
                }
            }

            // custom
            else if (j.MaxLife == 4) {

                // seconds
                if (j.CustomLifeDuration == 1) {
                    if (span.TotalSeconds >= j.CustomLife) {
                        disposeFile(file, delete);
                    }
                }

                // minutes
                else if (j.CustomLifeDuration == 2) {
                    if (span.TotalMinutes >= j.CustomLife) {
                        disposeFile(file, delete);
                    }
                }

                // hours
                else if (j.CustomLifeDuration == 3) {
                    if (span.TotalHours >= j.CustomLife) {
                        disposeFile(file, delete);
                    }
                }
            }
        }

        private static void disposeFile(string file, bool delete)
        {
            System.Windows.Forms.NotifyIcon trayIcon = new System.Windows.Forms.NotifyIcon();
            trayIcon.Icon = SystemIcons.Application;
            trayIcon.BalloonTipTitle = "Jettison";
            trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            trayIcon.Visible = true;
            trayIcon.BalloonTipText = String.Format(@"{0} was deleted", file);
            trayIcon.ShowBalloonTip(3000);
            string opType = "ERR";
            if (delete) {
                File.Delete(file);
                opType = "DEL";
            } else {
                FileOperationAPIWrapper.MoveToRecycleBin(file);
                opType = "REC";
            }

            // TODO: check settings first to see if logging is turned on
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";
            string log = String.Format(@"[{0}] {1} {2}", time.ToString(format), opType, file);
            string appdata = Environment.GetEnvironmentVariable("AppData");
            string logFile = appdata + @"\Jettison\log.txt";
            File.AppendAllText(logFile, log);
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

        public static void HandleSettings(Dictionary<string, bool> settings)
        {
            string runningDir = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string startupDir = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            string runningFile = Path.Combine(runningDir, "Jettison.exe");
            string shortcut = Path.Combine(startupDir, "Jettison.lnk");
            if (settings["RunOnStartup"]) {
                if (!File.Exists(shortcut)) {
                    FileOperationAPIWrapper.CreateShortcut("Jettison", startupDir, runningFile);
                }
            } else {
                if (File.Exists(shortcut)) {
                    File.Delete(shortcut);
                }
            }
        }
    }
}
