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
    public class InputStats4Model : PageModel
    {
        private IStatistics statistics;
        private ICourses courses;

        [BindProperty]
        public StatSheet MyStatSheet { get; private set; }

        [BindProperty]
        public int TotalScoreValue { get; set; }

        public int CurrentHoleId { get; private set; }

        public InputStats4Model(IStatistics statsRepo, ICourses courseRepo)
        {
            statistics = statsRepo;
            courses = courseRepo;

            MyStatSheet = statistics.GetSheet();

            CurrentHoleId = UserRepository.Instance.Get().CurrentHolesFilled;
        }

        public Course CurrentCourse { get; private set; }
        public Dictionary<int, Hole> Holes { get; private set; }

        public IActionResult OnGet()
        {
            CurrentCourse = courses.GetCourse(1);
            Holes = courses.AllHoles(1);

            return Page();
        }

        public IActionResult OnPost()
        {
            CurrentCourse = courses.GetCourse(1);
            Holes = courses.AllHoles(1);

            return Page();
        }

        public IActionResult OnPostTotalScore()
        {
            MyStatSheet.TotalScore = TotalScoreValue;
            statistics.UpdateSheet(MyStatSheet);

            return RedirectToPage("../ShowResults");
        }
    }
}
