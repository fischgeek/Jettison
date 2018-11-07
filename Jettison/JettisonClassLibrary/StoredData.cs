using System.Collections.Generic;

namespace JettisonClassLibrary
{
    class StoredData
    {
        public List<Jettison> Jettisons = new List<Jettison>();
        public Dictionary<string, bool> Settings = new Dictionary<string, bool>();
        private static StoredData instance = new StoredData();

        private StoredData() { }

        public static StoredData GetInstance()
        {
            return instance;
        }
    }
}
