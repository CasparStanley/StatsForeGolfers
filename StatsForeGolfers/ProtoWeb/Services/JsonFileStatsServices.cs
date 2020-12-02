﻿using Microsoft.AspNetCore.Hosting;
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
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Stats.Json"); }
        }

        public StatSheet AllStats()
        {
            return JsonFileReaderStats.ReadJson(JsonFileName);
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
