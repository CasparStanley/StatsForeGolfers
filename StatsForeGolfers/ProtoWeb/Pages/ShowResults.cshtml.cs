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

        public StatSheet MockSheet { get; private set; }

        public ShowResultsModel(IStatistics statsRepo, ICourses courseRepo)
        {
            statistics = statsRepo;
            courses = courseRepo;

            MockSheet = statistics.GetSheet();
        }

        public User CurrentUser { get; private set; }
        public Course CurrentCourse { get; private set; }
        public Dictionary<int, Hole> Holes { get; private set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public IActionResult OnGet()
        {
            CurrentUser = new User(); { CurrentUser.Name = "Caspar"; } // NEEDS TO BE A REAL USER FED THROUGH USER CREATION FLOW
            CurrentCourse = courses.GetCourse(1); // NEEDS CORRECT ID
            Holes = courses.AllHoles(1); // NEEDS CORRECT ID

            return Page();
        }

        public void OnPost(int btnId)
        {
            CurrentCourse = courses.GetCourse(1);
            Holes = courses.AllHoles(1);
            MockSheet = statistics.GetSheet();

            switch (btnId)
            {
                case 0:
                    {
                        MockSheet.ScrambleMiss++;
                        break;
                    }
                case 1:
                    {
                        MockSheet.ScrambleHit++;
                        break;
                    }
                default:
                    {
                        // Error
                        break;
                    }
            }

            MockSheet.TotalScrambleStrokes++;

            statistics.UpdateSheet(MockSheet);
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
