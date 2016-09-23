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
                            DateTime fileDate = File.GetCreationTime(file);
                            DateTime now = DateTime.Now;
                            TimeSpan span = now.Subtract(fileDate);

                            WriteLine("file: " + file);

                            // 24 hours
                            if (j.MaxLife == 1) {
                                if (span.Hours >= 24) {
                                    File.Delete(file);
                                    WriteLine("24 hours");
                                }
                            } 
                            
                            // 48 hours
                            else if (j.MaxLife == 2) {
                                if (span.Hours >= 48) {
                                    File.Delete(file);
                                    WriteLine("48 hours");
                                }
                            }

                            // 72 hours
                            else if (j.MaxLife == 3) {
                                if (span.Hours >= 72) {
                                    File.Delete(file);
                                    WriteLine("72 hours");
                                }
                            }

                            // custom
                            else if (j.MaxLife == 4) {
                                WriteLine("Custom");

                                // seconds
                                if (j.CustomLifeDuration == 1) {
                                    if (span.Seconds >= j.CustomLife) {
                                        File.Delete(file);
                                        WriteLine("Custom seconds");
                                    }
                                }

                                // minutes
                                else if (j.CustomLifeDuration == 2) {
                                    if (span.Minutes >= j.CustomLife) {
                                        File.Delete(file);
                                        WriteLine("Custom minutes");
                                    }
                                }

                                // hours
                                else if (j.CustomLifeDuration == 3) {
                                    if (span.Hours >= j.CustomLife) {
                                        File.Delete(file);
                                        WriteLine("Custom hours");
                                    }
                                }
                            }
                        }
                    }
                }
                Thread.Sleep(1000);
            }
        }

        private static void checkFileMinutes(string file)
        {

        }
    }
}
