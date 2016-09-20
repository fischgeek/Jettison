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
        const string dataFile = @"C:\temp\jettison.txt";
        private List<Jettison> allJettisons = new List<Jettison>();
        private static DataHandler instance = new DataHandler();

        private DataHandler()
        {
            allJettisons = JsonConvert.DeserializeObject<List<Jettison>>(File.ReadAllText(dataFile));
        }

        public static DataHandler getInstance()
        {
            return instance;
        }

        private void loadDataFile()
        {
            if (File.Exists(dataFile))
            {
                allJettisons = JsonConvert.DeserializeObject<List<Jettison>>(File.ReadAllText(dataFile));
            }
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

        public void registerDirectory(Jettison jettison)
        {
            allJettisons.Add(jettison);
            saveDataFile();
        }

        public string generateNewId()
        {
            return Guid.NewGuid().ToString();
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
