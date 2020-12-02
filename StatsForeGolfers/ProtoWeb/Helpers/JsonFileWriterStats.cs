using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ProtoWeb.Models;

namespace ProtoWeb.Helpers
{
    public class JsonFileWriterStats
    {
        public static void WriteToJson(StatSheet stats, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(stats,
                Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(JsonFileName, output);
        }
    }
}
