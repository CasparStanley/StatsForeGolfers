using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ProtoWeb.Models;

namespace ProtoWeb.Helpers
{
    public class JsonFileWritter
    {
        public static void WriteToJson(Dictionary<int, Hole> holes, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(holes,
                Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(JsonFileName, output);
        }
    }
}
