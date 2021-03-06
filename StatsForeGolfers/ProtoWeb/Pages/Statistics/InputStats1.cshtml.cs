using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoWeb.Interfaces;
using ProtoWeb.Models;

namespace ProtoWeb.Pages.Statistics
{
    public class InputStats1Model : PageModel
    {
        private IStatistics statistics;
        private ICourses courses;

        [BindProperty]
        public StatSheet MyStatSheet { get; private set; }

        public int CurrentHoleId { get; private set; }

        public InputStats1Model(IStatistics statsRepo, ICourses courseRepo)
        {
            statistics = statsRepo;
            courses = courseRepo;

            // TO USE A SHEET THAT IS SAVED BETWEEN RESTARTING PROGRAM. DELETE ABOVE TO DO THIS^^
            MyStatSheet = statistics.GetSheet();

            CurrentHoleId = UserRepository.Instance.Get().CurrentHolesFilled;
        }

        public Course CurrentCourse { get; private set; }
        public Dictionary<int, Hole> Holes { get; private set; }

        public IActionResult OnGet()
        {
            CurrentCourse = courses.GetCourse(1);
            Holes = courses.AllHoles(1);
            statistics.UpdateSheet(MyStatSheet);

            return Page();
        }

        public IActionResult OnPostMissFairwayLeft()
        {
            MyStatSheet.FairWayMissLeft++;
            MyStatSheet.TotalFairwayStrokes++;
            statistics.UpdateSheet(MyStatSheet);

            return RedirectToPage("InputStats2");
        }
        public IActionResult OnPostHitFairway()
        {
            MyStatSheet.FairWayHit++;
            MyStatSheet.TotalFairwayStrokes++;
            statistics.UpdateSheet(MyStatSheet);

            return RedirectToPage("InputStats2");
        }
        public IActionResult OnPostMissFairwayRight()
        {
            MyStatSheet.FairWayMissRight++;
            MyStatSheet.TotalFairwayStrokes++;
            statistics.UpdateSheet(MyStatSheet);

            return RedirectToPage("InputStats2");
        }
    }
}
