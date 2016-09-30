using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JettisonClassLibrary
{
    class StoredData
    {
        public List<Jettison> Jettisons = new List<Jettison>();
        public Dictionary<string, bool> Settings = new Dictionary<string, bool>();
        private static StoredData instance = new StoredData();

        private StoredData() { }

        public static StoredData getInstance()
        {
            return instance;
        }
    }
}
