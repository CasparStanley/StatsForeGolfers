using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;
using ProtoWeb.Helpers;
using ProtoWeb.Interfaces;
using ProtoWeb.Models;

namespace ProtoWeb.Services
{
    public class JsonFileHole : IHoleRepository
    {
        public IWebHostEnvironment WebHostEnvironment { get; }

        public JsonFileHole(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Course.Json"); }
        }

        public Dictionary<int, Hole> AllHoles()
        {
            return JsonFileReader.ReadJson(JsonFileName);
        }
        public void AddHole(Hole hole)
        {
            Dictionary<int, Hole> holes = AllHoles();
            holes.Add(hole.HoleNo, hole);
            JsonFileWritter.WriteToJson(holes, JsonFileName);
        }

        public Dictionary<int, Hole> FilterHole(string criteria)
        {

            Dictionary<int, Hole> holes = AllHoles();
            Dictionary<int, Hole> filteredHoles = new Dictionary<int, Hole>();
            foreach (var h in holes.Values)
            {
                if (Convert.ToString(h.Par) == (criteria))
                {
                    filteredHoles.Add(h.HoleNo, h);
                }
            }
            return filteredHoles;
        }

        public Hole GetHole(int holeNo)
        {
            Dictionary<int, Hole> holes = AllHoles();
            Hole foundHole = holes[holeNo];
            return foundHole;
        }

        public void UpdateHole(Hole hole)
        {
            Dictionary<int, Hole> holes = AllHoles();
            Hole foundHole = holes[hole.HoleNo];
            foundHole.HoleNo = hole.HoleNo;
            foundHole.Length = hole.Length;
            foundHole.Par = hole.Par;
            foundHole.Handicap = hole.Handicap;
            JsonFileWritter.WriteToJson(holes, JsonFileName);

        }

        public void DeleteHole(Hole hole)
        {
            Dictionary<int, Hole> holes = AllHoles();
            holes.Remove(hole.HoleNo);
            JsonFileWritter.WriteToJson(holes, JsonFileName);
        }
    }
}
