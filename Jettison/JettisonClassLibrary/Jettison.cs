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
