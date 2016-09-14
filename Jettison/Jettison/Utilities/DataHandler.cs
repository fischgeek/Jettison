using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jettison.Utilities
{
    class DataHandler
    {
        const string dataFile = @"C:\temp\jettison.txt";

        public string loadDataFile()
        {
            string jsonData = "Data file not found.";
            if (File.Exists(dataFile))
            {
                jsonData = File.ReadAllText(dataFile);
                Jettison jettison = JsonConvert.DeserializeObject<Jettison>(jsonData);
            }
            return jsonData;
        }
    }
}

/* sample data
{
  "jettisons": [
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
}
*/
