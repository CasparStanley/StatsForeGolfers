using Newtonsoft.Json;
using ProtoWeb.Models;
using System.Collections.Generic;
using System.IO;

namespace ProtoWeb.Helpers
{
    public class JsonFileReaderStats
    {
        public static StatSheet ReadJson(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);
            return JsonConvert.DeserializeObject<StatSheet>(jsonString);
        }
    }
}
