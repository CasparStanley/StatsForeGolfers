﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProtoWeb.Interfaces;
using ProtoWeb.Models;

namespace ProtoWeb.Helpers
{
    public class JsonFileReader
    {
        public static Dictionary<int, Hole> ReadJson(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);
            return JsonConvert.DeserializeObject<Dictionary<int, Hole>>(jsonString);
        }
    }
}
