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
    public class InputStats3Model : PageModel
    {
        private IStatistics statistics;
        private ICourses courses;

        [BindProperty]
        public StatSheet MockSheet { get; private set; }

        public int CurrentHoleId { get; private set; }

        public InputStats3Model(IStatistics statsRepo, ICourses courseRepo)
        {
            statistics = statsRepo;
            courses = courseRepo;

            MockSheet = statistics.GetSheet();

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

        public IActionResult OnPostScrambleIn()
        {
            MockSheet.ScrambleHit++;
            MockSheet.TotalScrambleStrokes++;
            statistics.UpdateSheet(MockSheet);

            int id = UserRepository.Instance.Get().CurrentCourseId;
            if (courses.GetCourse(id).Holes.Count > UserRepository.Instance.Get().CurrentHolesFilled)
            {
                UserRepository.Instance.Get().CurrentHolesFilled++;
                return RedirectToPage("InputStats1");
            }
            else
            {
                return RedirectToPage("../ShowResults");
            }
        }

        public IActionResult OnPostScrambleOut()
        {
            MockSheet.ScrambleMiss++;
            MockSheet.TotalScrambleStrokes++;
            statistics.UpdateSheet(MockSheet);

            int id = UserRepository.Instance.Get().CurrentCourseId;
            if (courses.GetCourse(id).Holes.Count > UserRepository.Instance.Get().CurrentHolesFilled)
            {
                UserRepository.Instance.Get().CurrentHolesFilled++;
                return RedirectToPage("InputStats1");
            }
            else
            {
                return RedirectToPage("../ShowResults");
            }
        }
    }
}
