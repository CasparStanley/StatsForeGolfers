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
    public class InputStats2Model : PageModel
    {
        private IStatistics statistics;
        private ICourses courses;

        [BindProperty]
        public StatSheet MockSheet { get; private set; }

        public InputStats2Model(IStatistics statsRepo, ICourses courseRepo)
        {
            statistics = statsRepo;
            courses = courseRepo;

            MockSheet = statistics.GetSheet();
        }

        public Course CurrentCourse { get; private set; }
        public Dictionary<int, Hole> Holes { get; private set; }

        public void OnGet()
        {
            CurrentCourse = courses.GetCourse(1);
            Holes = courses.AllHoles(1);
        }

        public IActionResult OnPostMissGreenLeft()
        {
            MockSheet.GreenMissLeft++;
            MockSheet.TotalGreenStrokes++;
            statistics.UpdateSheet(MockSheet);

            return RedirectToPage("InputStats3");
        }

        public IActionResult OnPostHitGreen()
        {
            MockSheet.GreenHit++;
            MockSheet.TotalGreenStrokes++;
            statistics.UpdateSheet(MockSheet);

            return RedirectToPage("../ShowResults");
        }

        public IActionResult OnPostMissGreenRight()
        {
            MockSheet.GreenMissRight++;
            MockSheet.TotalGreenStrokes++;
            statistics.UpdateSheet(MockSheet);

            return RedirectToPage("InputStats3");
        }
    }
}
