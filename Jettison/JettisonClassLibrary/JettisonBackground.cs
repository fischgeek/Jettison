using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace JettisonClassLibrary
{
    public class JettisonBackground
    {
        public static DataHandler dh = DataHandler.getInstance();
        public static Dictionary<string, bool> settings = dh.getSettings();
        public static System.Windows.Forms.NotifyIcon trayIcon = new System.Windows.Forms.NotifyIcon();
        //private Action<string> Alert;

        //public static Jettison MakeMeAThing(Action<string> Alert)
        //{
        //    var j = new Jettison();
        //    j.Alert = Alert;
        //    return j;
        //}
        //private void IDeletedSomething()
        //{
        //    this.Alert("Hello world");
        //}

        public static void checkJettisons()
        {
            //DataHandler dh = DataHandler.getInstance();
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
            string opType = "ERR";
            if (delete) {
                File.Delete(file);
                opType = "DEL";
            } else {
                FileOperationAPIWrapper.MoveToRecycleBin(file);
                opType = "REC";
            }

            bool logOperation = false;
            logOperation = settings["LogHistory"];

            if (logOperation) {
                DateTime time = DateTime.Now;
                string format = "yyyy-MM-dd HH:mm:ss";
                string log = String.Format(@"[{0}] {1} {2}", time.ToString(format), opType, file);
                string appdata = Environment.GetEnvironmentVariable("AppData");
                string logFile = appdata + @"\Jettison\log.txt";
                using (StreamWriter s = File.AppendText(logFile)) {
                    s.WriteLine(log);
                }
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
