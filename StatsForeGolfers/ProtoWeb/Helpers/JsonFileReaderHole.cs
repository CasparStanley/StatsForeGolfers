using Newtonsoft.Json;
using ProtoWeb.Models;
using System.Collections.Generic;
using System.IO;

namespace ProtoWeb.Helpers
{
    public class JsonFileReaderHole
    {
        public static Dictionary<int, Hole> ReadJson(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);
            return JsonConvert.DeserializeObject<Dictionary<int, Hole>>(jsonString);
        }
    }
}
