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
        public StatSheet MockSheet { get; private set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public IActionResult OnGet()
        {
            Holes = course.AllHoles();

            // -------------------------------------------------------------------------------------------------------------------
            // NEEDS TO BE A SPECIFIC STATSHEET CONNECTED TO THE USER
            // THIS IS ALL MOCK DATA, WE NEED TO USE A REAL SHEET THAT THE USER FILLS
            MockSheet = new StatSheet()
            {
                TotalFairwayStrokes = 35,
                FairWayHit = 20,
                FairWayMissLeft = 5,
                TotalGreenStrokes = 32,
                GreenHit = 21,
                GreenMissLeft = 6,
                TotalScrambleStrokes = 10,
                ScrambleHit = 8,
            };

            MockSheet.FairWayMissRight = MockSheet.TotalFairwayStrokes - MockSheet.FairWayHit - MockSheet.FairWayMissLeft;
            MockSheet.GreenMissRight = MockSheet.TotalGreenStrokes - MockSheet.GreenHit - MockSheet.GreenMissLeft;
            MockSheet.ScrambleMiss = MockSheet.TotalScrambleStrokes - MockSheet.ScrambleHit;
            MockSheet.TotalHits = MockSheet.FairWayHit + MockSheet.GreenHit; // Does Scramble count towards this?
            // -------------------------------------------------------------------------------------------------------------------

            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Holes = course.FilterHole(FilterCriteria);
            }
            return Page();
        }
    }
}
