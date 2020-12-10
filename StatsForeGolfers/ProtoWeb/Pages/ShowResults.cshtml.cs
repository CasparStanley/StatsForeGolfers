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
        private ICourses courses;

        public ShowResultsModel(IStatistics statsRepo, ICourses courseRepo)
        {
            statistics = statsRepo;
            courses = courseRepo;
        }

        public User CurrentUser { get; private set; }
        public Course CurrentCourse { get; private set; }
        public Dictionary<int, Hole> Holes { get; private set; }
        public StatSheet MockSheet { get; private set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public IActionResult OnGet()
        {
            CurrentUser = new User(); { CurrentUser.Name = "Caspar"; } // NEEDS TO BE A REAL USER FED THROUGH USER CREATION FLOW
            CurrentCourse = courses.GetCourse(1); // NEEDS CORRECT ID
            Holes = courses.AllHoles(1); // NEEDS CORRECT ID

            // -------------------------------------------------------------------------------------------------------------------
            // NEEDS TO BE A SPECIFIC STATSHEET CONNECTED TO THE USER
            // THIS IS ALL MOCK DATA, WE NEED TO USE A REAL SHEET THAT THE USER FILLS
            MockSheet = statistics.Sheet();
            
            MockSheet.TotalFairwayStrokes = 35;
            MockSheet.FairWayHit = 20;
            MockSheet.FairWayMissLeft = 5;
            MockSheet.TotalGreenStrokes = 32;
            MockSheet.GreenHit = 21;
            MockSheet.GreenMissLeft = 6;
            MockSheet.TotalScrambleStrokes = 10;
            MockSheet.ScrambleHit = 8;
            

            MockSheet.FairWayMissRight = MockSheet.TotalFairwayStrokes - MockSheet.FairWayHit - MockSheet.FairWayMissLeft;
            MockSheet.GreenMissRight = MockSheet.TotalGreenStrokes - MockSheet.GreenHit - MockSheet.GreenMissLeft;
            MockSheet.ScrambleMiss = MockSheet.TotalScrambleStrokes - MockSheet.ScrambleHit;
            MockSheet.TotalHits = MockSheet.FairWayHit + MockSheet.GreenHit; // Does Scramble count towards this?
            // -------------------------------------------------------------------------------------------------------------------

            return Page();
        }

        public int FairwayHit()
        {
            return (int)(MockSheet.PercentageCalculator(MockSheet.FairWayHit, MockSheet.TotalFairwayStrokes) * 100);
        }

        public int FairwayMiss(bool left)
        {
            if (left)
                return (int)(MockSheet.PercentageCalculator(MockSheet.FairWayMissLeft, MockSheet.TotalFairwayStrokes) * 100);
            else
                return (int)(MockSheet.PercentageCalculator(MockSheet.FairWayMissRight, MockSheet.TotalFairwayStrokes) * 100);
        }

        public int GreenHit()
        {
            return (int)(MockSheet.PercentageCalculator(MockSheet.GreenHit, MockSheet.TotalGreenStrokes) * 100);
        }

        public int GreenMiss(bool left)
        {
            if (left)
                return (int)(MockSheet.PercentageCalculator(MockSheet.GreenMissLeft, MockSheet.TotalGreenStrokes) * 100);
            else
                return (int)(MockSheet.PercentageCalculator(MockSheet.GreenMissRight, MockSheet.TotalGreenStrokes) * 100);
        }

        public int Scramble(bool hit)
        {
            if (hit)
                return (int)(MockSheet.PercentageCalculator(MockSheet.ScrambleHit, MockSheet.TotalScrambleStrokes) * 100);
            else
                return (int)(MockSheet.PercentageCalculator(MockSheet.ScrambleMiss, MockSheet.TotalScrambleStrokes) * 100);
        }
    }
}
