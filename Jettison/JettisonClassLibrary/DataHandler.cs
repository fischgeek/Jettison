﻿using Newtonsoft.Json;
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
        public bool instanceLoaded = false;

        private DataHandler()
        {
            instanceLoaded = true;
            string dataDir = appdata + @"\Jettison\";
            if (!Directory.Exists(dataDir)) {
				try {
					Directory.CreateDirectory(dataDir);
				} catch {
					throw new Exception("Failed to create directory");
				}
            }
            if (!File.Exists(dataFile)) {
				try {
					using (File.Create(dataFile)) { }
				} catch {
					throw new Exception("Failed to create data file.");
				}
            }

            string dataFileContents = string.Empty;
            try {
                dataFileContents = File.ReadAllText(dataFile);
            } catch (Exception ex) {
                WriteLine(ex.Message);
				throw new Exception("Failed to read the data file.");
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

        public bool showMainForm()
        {
            if (storedData.Settings.ContainsKey("ShowOnStart")) {
                return storedData.Settings["ShowOnStart"];
            } else {
                return true;
            }
        }

        public bool closeToTray()
        {
            if (storedData.Settings.ContainsKey("CloseToTray")) {
                return storedData.Settings["CloseToTray"];
            } else {
                return false;
            }
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
                firstTimeSettings["ShowOnStart"] = true;
                firstTimeSettings["CloseToTray"] = false;
                firstTimeSettings["LogHistory"] = false;
                firstTimeSettings["DisplayAlerts"] = false;
                updateSettings(firstTimeSettings);
            }
            return storedData.Settings;
        }

        public void updateSettings(Dictionary<string, bool> settingsFromDialog)
        {
            storedData.Settings = settingsFromDialog;
            saveDataFile();
        }

        public JettisonFile addFileToJettison(Jettison jettison, string file)
        {
            JettisonFile newFile = new JettisonFile();
            newFile.FullPath = file;
            newFile.DropTime = DateTime.Now;
            jettison.JettisonFiles.Add(newFile);
            saveDataFile();
			JFLog.Log("INFO", file + " was added");
			return newFile;
        }

        public void removeFileFromJettison(Jettison j, string file)
        {
            j.JettisonFiles.Remove(j.JettisonFiles.First(x => x.FullPath == file));
            saveDataFile();
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
