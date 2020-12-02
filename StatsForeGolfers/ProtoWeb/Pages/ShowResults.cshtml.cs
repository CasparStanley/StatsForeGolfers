using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoWeb.Interfaces;
using ProtoWeb.Models;
using ProtoWeb.Helpers;

namespace ProtoWeb.Pages
{
    public class ShowResultsModel : PageModel
    {
        private IStatistics statistics;
        private IHoleRepository course;

        public ShowResultsModel(IStatistics statsRepo, IHoleRepository courseRepo)
        {
            statistics = statsRepo;
            course = courseRepo;
        }

        public Dictionary<int, Hole> Holes { get; private set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public IActionResult OnGet()
        {
            Holes = course.AllHoles();
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Holes = course.FilterHole(FilterCriteria);
            }
            JsonFileWriterStats.WriteToJson(statistics, "Stats.Json");
            return Page();
        }
    }
}
