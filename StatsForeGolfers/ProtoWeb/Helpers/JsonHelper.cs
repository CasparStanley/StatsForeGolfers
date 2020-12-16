using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProtoWeb.Models;

namespace ProtoWeb.Helpers
{
    public class JsonHelper
    {
        public static Dictionary<int, Course> ReadCourse(string filename)
        {
            Dictionary<int, Course> jsonObject = new Dictionary<int, Course>();

            if (File.Exists(filename))
            {
                try
                {
                    string jsonString = File.ReadAllText(filename);
                    jsonObject = JsonConvert.DeserializeObject<Dictionary<int, Course>>(jsonString);
                }
                catch { throw new ArgumentException($"FILE WITH NAME '{filename}' DOESN'T EXIST"); }
            }

            return jsonObject;
        }

        public static StatSheet ReadStat(string filename)
        {
            StatSheet jsonObject = new StatSheet();

            if (File.Exists(filename))
            {
                try
                {
                    string jsonString = File.ReadAllText(filename);
                    jsonObject = JsonConvert.DeserializeObject<StatSheet>(jsonString);
                }
                catch { throw new ArgumentException($"FILE WITH NAME '{filename}' DOESN'T EXIST"); }
            }

            return jsonObject;
        }

        public static List<ProStats> ReadProStat(string filename)
        {
            List<ProStats> jsonObject = new List<ProStats>();

            if (File.Exists(filename))
            {
                try
                {
                    string jsonString = File.ReadAllText(filename);
                    jsonObject = JsonConvert.DeserializeObject<List<ProStats>>(jsonString);
                }
                catch { throw new ArgumentException($"FILE WITH NAME '{filename}' DOESN'T EXIST"); }
            }

            return jsonObject;
        }

        public static bool WriteCourse(Dictionary<int, Course> courses, string filename)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(courses,
                    Formatting.Indented);

                File.WriteAllText(filename, jsonString);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool WriteStat(StatSheet stats, string filename)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(stats,
                    Formatting.Indented);

                File.WriteAllText(filename, jsonString);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool WriteProStat(List<ProStats> pStats, string filename)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(pStats,
                    Formatting.Indented);

                File.WriteAllText(filename, jsonString);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
