using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ProtoWeb.Models;

namespace ProtoWeb.Helpers
{
    public class JsonFileWritterCourses
    {
        public static void WriteToJson(Dictionary<int, Course> courses, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(courses,
                Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(JsonFileName, output);
        }
    }
}