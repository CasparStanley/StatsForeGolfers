using Microsoft.AspNetCore.Hosting;
using ProtoWeb.Helpers;
using ProtoWeb.Interfaces;
using ProtoWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProtoWeb.Services
{
    public class JsonFileStats : IStatistics
    {
        public IWebHostEnvironment WebHostEnvironment { get; }

        public JsonFileStats(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Stats.json"); }
        }

        public void CreateSheet(StatSheet sheet)
        {
            JsonHelper.WriteStat(sheet, JsonFileName);
        }

        public void UpdateSheet(StatSheet sheet)
        {
            JsonHelper.WriteStat(sheet, JsonFileName);
        }

        public StatSheet GetSheet()
        {
            try { return JsonHelper.ReadStat(JsonFileName); }
            catch (ArgumentException aExc) { Console.WriteLine(aExc); return null; }
        }

        public double PercentageCalculator(double number, double totalNumber)
        {
            double result = 0;
            if (totalNumber != 0 && number != 0)
            {
                result = number / totalNumber;
            }

            return result;
        }
    }
}
