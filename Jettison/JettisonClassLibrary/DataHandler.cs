using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Diagnostics.Debug;

namespace JettisonClassLibrary
{
    public class DataHandler
    {
        private string appdata = Environment.GetEnvironmentVariable("AppData");
        private string dataFile = Environment.GetEnvironmentVariable("AppData") + @"\Jettison\jettison.json";
        private string settingsFile = Environment.GetEnvironmentVariable("AppData") + @"\Jettison\settings.json";
        private List<Jettison> allJettisons = new List<Jettison>();
        private Dictionary<string, bool> settings = new Dictionary<string, bool>();
        private StoredData storedData = StoredData.GetInstance();
        private static DataHandler instance = new DataHandler();
        public bool instanceLoaded = false;

        private DataHandler()
        {
            instanceLoaded = true;
            string dataDir = appdata + @"\Jettison\";
            if (!Directory.Exists(dataDir))
            {
				try
                {
					Directory.CreateDirectory(dataDir);
				}
                catch
                {
					throw new Exception("Failed to create directory");
				}
            }
            if (!File.Exists(dataFile)) {
				try
                {
					using (File.Create(dataFile)) { }
				}
                catch
                {
					throw new Exception("Failed to create data file.");
				}
            }

            string dataFileContents = string.Empty;
            try
            {
                dataFileContents = File.ReadAllText(dataFile);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
				throw new Exception("Failed to read the data file.");
            }
            storedData = JsonConvert.DeserializeObject<StoredData>(dataFileContents);
            if (storedData == null)
            {
                storedData = StoredData.GetInstance();
            }
        }

        public static DataHandler GetInstance()
        {
            return instance;
        }

        public bool ShowMainForm()
        {
            if (storedData.Settings.ContainsKey("ShowOnStart"))
            {
                return storedData.Settings["ShowOnStart"];
            }
            else
            {
                return true;
            }
        }

        public bool CloseToTray()
        {
            if (storedData.Settings.ContainsKey("CloseToTray"))
            {
                return storedData.Settings["CloseToTray"];
            }
            else
            {
                return false;
            }
        }

        private void SaveDataFile()
        {
            string jsonData = JsonConvert.SerializeObject(storedData);
            File.WriteAllText(dataFile, jsonData);
        }

        public List<Jettison> GetAllJettisons()
        {
            return storedData.Jettisons;
        }

        public Jettison GetJettisonById(string id)
        {
            Jettison jettison = (from j in storedData.Jettisons
                                where j.Id == id
                                select j).SingleOrDefault();
            return jettison;
        }

        public Jettison GetJettisonByDirectory(string directory)
        {
            Jettison jettison = (from j in storedData.Jettisons
                                 where j.Directory == directory
                                 select j).SingleOrDefault();
            return jettison;
        }

        private bool JettisonExists(Jettison jettison)
        {
            if (storedData.Jettisons.Count > 0)
            {
                return storedData.Jettisons.Exists(x => x.Id == jettison.Id);
            } else {
                return false;
            }
        }

        public void RegisterDirectory(Jettison jettison)
        {
            if (JettisonExists(jettison))
            {
                storedData.Jettisons.Remove(GetJettisonById(jettison.Id));
            }
            storedData.Jettisons.Add(jettison);
            SaveDataFile();
        }

        public void RemoveDirectory(Jettison jettison)
        {
            storedData.Jettisons.Remove(jettison);
            SaveDataFile();
        }

        public string GenerateNewId()
        {
            return Guid.NewGuid().ToString();
        }

        public Dictionary<string, bool> GetSettings()
        {
            if (storedData.Settings == null || storedData.Settings.Count == 0)
            {
                Dictionary<string, bool> firstTimeSettings = new Dictionary<string, bool>();
                firstTimeSettings["RunOnStartup"] = true;
                firstTimeSettings["ShowOnStart"] = true;
                firstTimeSettings["CloseToTray"] = false;
                firstTimeSettings["LogHistory"] = false;
                firstTimeSettings["DisplayAlerts"] = false;
                UpdateSettings(firstTimeSettings);
            }
            return storedData.Settings;
        }

        public void UpdateSettings(Dictionary<string, bool> settingsFromDialog)
        {
            storedData.Settings = settingsFromDialog;
            SaveDataFile();
        }

        public JettisonFile AddFileToJettison(Jettison jettison, string file)
        {
            JettisonFile newFile = new JettisonFile();
            newFile.FullPath = file;
            newFile.DropTime = DateTime.Now;
            jettison.JettisonFiles.Add(newFile);
            SaveDataFile();
			JFLog.Log("INFO", file + " was added");
			return newFile;
        }

        public void RemoveFileFromJettison(Jettison j, string file)
        {
            j.JettisonFiles.Remove(j.JettisonFiles.First(x => x.FullPath == file));
            SaveDataFile();
        }
    }
}

/* sample data (c:\temp\jettison.txt)
[
    {
    "Directory": "directory1",
    "MaxLife": 1,
    "CustomLife": 1,
    "CustomLifeDuration": 1
    },
    {
    "Directory": "directory2",
    "MaxLife": 2,
    "CustomLife": 2,
    "CustomLifeDuration": 2
    },
    {
    "Directory": "directory3",
    "MaxLife": 3,
    "CustomLife": 3,
    "CustomLifeDuration": 3
    }
]
*/
