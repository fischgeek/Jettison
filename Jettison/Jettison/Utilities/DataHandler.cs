using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Diagnostics.Debug;

namespace Jettison.Utilities
{
    class DataHandler
    {
        const string dataFile = @"C:\temp\jettison.txt";
        private List<Jettison> allJettisons = new List<Jettison>();

        public DataHandler()
        {
            loadDataFile();
        }

        private void loadDataFile()
        {
            if (File.Exists(dataFile))
            {
                allJettisons = JsonConvert.DeserializeObject<List<Jettison>>(File.ReadAllText(dataFile));
            }
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
