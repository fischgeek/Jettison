using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using static System.Diagnostics.Debug;

namespace JettisonClassLibrary
{
    public class Jettison
    {
        public string Id { get; set; }
        public string Directory { get; set; }
        public int MaxLife { get; set; }
        public int CustomLife { get; set; }
        public int CustomLifeDuration { get; set; }

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

        public static void checkJettisons(bool flag)
        {
            DataHandler dh = DataHandler.getInstance();
            while (true) {
                if (!flag) {
                    break;
                }
                foreach (var j in dh.getAllJettisons()) {
                    if (System.IO.Directory.Exists(j.Directory)) {
                        string[] files = System.IO.Directory.GetFiles(j.Directory);
                        foreach (string file in files) {
                            checkFile(file);                            
                        }
                    }
                }
                Thread.Sleep(1000);
            }
        }

        private static void checkFile(string file)
        {
            DateTime fileDate = File.GetCreationTime(file);
            DateTime now = DateTime.Now;
            TimeSpan span = now.Subtract(fileDate);
            WriteLine("span: " + span.Minutes);
        }
    }
}
