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
            allJettisons = JsonConvert.DeserializeObject<List<Jettison>>(dataFileContents);
            if (allJettisons == null) {
                allJettisons = new List<Jettison>();
            }

            string settingsFileContents = string.Empty;
            try {
                settingsFileContents = File.ReadAllText(settingsFile);
            } catch (Exception ex) {
                WriteLine(ex.Message);
            }
            settings = JsonConvert.DeserializeObject<Dictionary<string, bool>>(settingsFileContents);
        }

        public static DataHandler getInstance()
        {
            return instance;
        }

        private void saveDataFile()
        {
            string jsonData = JsonConvert.SerializeObject(allJettisons);
            File.WriteAllText(dataFile, jsonData);
        }

        public List<Jettison> getAllJettisons()
        {
            return allJettisons;
        }

        public Jettison getJettisonById(string id)
        {
            Jettison jettison = (from j in allJettisons
                                where j.Id == id
                                select j).SingleOrDefault();
            return jettison;
        }

        public Jettison getJettisonByDirectory(string directory)
        {
            Jettison jettison = (from j in allJettisons
                                 where j.Directory == directory
                                 select j).SingleOrDefault();
            return jettison;
        }

        private bool jettisonExists(Jettison jettison)
        {
            if (allJettisons.Count > 0) {
                return allJettisons.Exists(x => x.Id == jettison.Id);
            } else {
                return false;
            }
        }

        public void registerDirectory(Jettison jettison)
        {
            if (jettisonExists(jettison)) {
                allJettisons.Remove(getJettisonById(jettison.Id));
            }
            allJettisons.Add(jettison);
            saveDataFile();
        }

        public void removeDirectory(Jettison jettison)
        {
            allJettisons.Remove(jettison);
            saveDataFile();
        }

        public string generateNewId()
        {
            return Guid.NewGuid().ToString();
        }

        public Dictionary<string, bool> getSettings()
        {
            if (settings == null) {
                Dictionary<string, bool> firstTimeSettings = new Dictionary<string, bool>();
                firstTimeSettings["RunOnStartup"] = true;
                updateSettings(firstTimeSettings);
            }
            return settings;
        }

        public void updateSettings(Dictionary<string, bool> settingsFromDialog)
        {
            settings = settingsFromDialog;
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
