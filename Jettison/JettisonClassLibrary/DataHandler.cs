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
        private StoredData storedData = StoredData.getInstance();
        private static DataHandler instance = new DataHandler();

        private DataHandler()
        {
            string dataDir = appdata + @"\Jettison\";
            if (!Directory.Exists(dataDir)) {
                Directory.CreateDirectory(dataDir);
            }
            if (!File.Exists(dataFile)) {
                using (File.Create(dataFile)) { }
            }
            if (!File.Exists(settingsFile)) {
                using (File.Create(settingsFile)) { }
            }

            string dataFileContents = string.Empty;
            try {
                dataFileContents = File.ReadAllText(dataFile);
            } catch (Exception ex) {
                WriteLine(ex.Message);
            }
            storedData = JsonConvert.DeserializeObject<StoredData>(dataFileContents);
            if (storedData == null) {
                storedData = StoredData.getInstance();
            }
        }

        public static DataHandler getInstance()
        {
            return instance;
        }

        private void saveDataFile()
        {
            string jsonData = JsonConvert.SerializeObject(storedData);
            File.WriteAllText(dataFile, jsonData);
        }

        public List<Jettison> getAllJettisons()
        {
            return storedData.Jettisons;
        }

        public Jettison getJettisonById(string id)
        {
            Jettison jettison = (from j in storedData.Jettisons
                                where j.Id == id
                                select j).SingleOrDefault();
            return jettison;
        }

        public Jettison getJettisonByDirectory(string directory)
        {
            Jettison jettison = (from j in storedData.Jettisons
                                 where j.Directory == directory
                                 select j).SingleOrDefault();
            return jettison;
        }

        private bool jettisonExists(Jettison jettison)
        {
            if (storedData.Jettisons.Count > 0) {
                return storedData.Jettisons.Exists(x => x.Id == jettison.Id);
            } else {
                return false;
            }
        }

        public void registerDirectory(Jettison jettison)
        {
            if (jettisonExists(jettison)) {
                storedData.Jettisons.Remove(getJettisonById(jettison.Id));
            }
            storedData.Jettisons.Add(jettison);
            saveDataFile();
        }

        public void removeDirectory(Jettison jettison)
        {
            storedData.Jettisons.Remove(jettison);
            saveDataFile();
        }

        public string generateNewId()
        {
            return Guid.NewGuid().ToString();
        }

        public Dictionary<string, bool> getSettings()
        {
            if (storedData.Settings == null || storedData.Settings.Count == 0) {
                Dictionary<string, bool> firstTimeSettings = new Dictionary<string, bool>();
                firstTimeSettings["RunOnStartup"] = true;
                updateSettings(firstTimeSettings);
            }
            return storedData.Settings;
        }

        public void updateSettings(Dictionary<string, bool> settingsFromDialog)
        {
            storedData.Settings = settingsFromDialog;
            string settingsString = JsonConvert.SerializeObject(settingsFromDialog);
            File.WriteAllText(settingsFile, settingsString);
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
