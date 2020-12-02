using System;
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
    public class JsonFileReaderCourses
    {
        public static Dictionary<int, Course> ReadJson(string JsonFileName)
        {
            /*Course courses = new Course();
            courses.Id = 2;
            courses.Name = ";DD";
            Hole hole = new Hole();
            hole.Handicap = 20;
            hole.HoleNo = 1;
            hole.Length = 40;
            hole.Par = 4;
            Hole hole1 = new Hole();
            hole1.Handicap = 20;
            hole1.HoleNo = 2;
            hole1.Length = 40;
            hole1.Par = 4;
            Dictionary<int,Hole> dictionary = new Dictionary<int, Hole>();
            dictionary.Add(hole1.HoleNo,hole1);
           dictionary.Add(hole.HoleNo,hole);
           courses.Holes = dictionary;

            //courses.Holes.Add(1, new Hole());
            //courses.Holes.Add(2, new Hole());

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(courses,
                Newtonsoft.Json.Formatting.Indented);
            
            File.WriteAllText(JsonFileName, output);*/
            string jsonString = File.ReadAllText(JsonFileName);
            return JsonConvert.DeserializeObject<Dictionary<int, Course>>(jsonString);
        }
    }
}