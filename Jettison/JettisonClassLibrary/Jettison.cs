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

        public static void checkJettisons()
        {
            DataHandler dh = DataHandler.getInstance();
            List<Jettison> all = dh.getAllJettisons();
            while (all != null && all.Count > 0) {
                foreach (var j in all) {
                    if (System.IO.Directory.Exists(j.Directory)) {
                        string[] files = System.IO.Directory.GetFiles(j.Directory);
                        foreach (string file in files) {
                            DateTime fileDate = File.GetCreationTime(file);
                            DateTime now = DateTime.Now;
                            TimeSpan span = now.Subtract(fileDate);

                            // 24 hours
                            if (j.MaxLife == 1) {
                                if (span.TotalHours >= 24) {
                                    File.Delete(file);
                                }
                            } 
                            
                            // 48 hours
                            else if (j.MaxLife == 2) {
                                if (span.TotalHours >= 48) {
                                    File.Delete(file);
                                }
                            }

                            // 72 hours
                            else if (j.MaxLife == 3) {
                                if (span.TotalHours >= 72) {
                                    File.Delete(file);
                                }
                            }

                            // custom
                            else if (j.MaxLife == 4) {

                                // seconds
                                if (j.CustomLifeDuration == 1) {
                                    if (span.TotalSeconds >= j.CustomLife) {
                                        File.Delete(file);
                                    }
                                }

                                // minutes
                                else if (j.CustomLifeDuration == 2) {
                                    if (span.TotalMinutes >= j.CustomLife) {
                                        File.Delete(file);
                                    }
                                }

                                // hours
                                else if (j.CustomLifeDuration == 3) {
                                    if (span.TotalHours >= j.CustomLife) {
                                        File.Delete(file);
                                    }
                                }
                            }
                        }
                    }
                }
                Thread.Sleep(1000);
            }
        }
    }
}
