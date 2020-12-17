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
        public StatSheet MyStatSheet { get; private set; }

        public int CurrentHoleId { get; private set; }

        public InputStats3Model(IStatistics statsRepo, ICourses courseRepo)
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

        public IActionResult OnPostScrambleIn()
        {
            MyStatSheet.ScrambleHit++;
            MyStatSheet.TotalScrambleStrokes++;
            statistics.UpdateSheet(MyStatSheet);

            int id = UserRepository.Instance.Get().CurrentCourseId;
            if (courses.GetCourse(id).Holes.Count > UserRepository.Instance.Get().CurrentHolesFilled)
            {
                UserRepository.Instance.Get().CurrentHolesFilled++;

                // If the current holes par is more than 3, we go to the fairway. Otherwise, we skip the fairway shot.
                if (courses.GetCourse(id).Holes[UserRepository.Instance.Get().CurrentHolesFilled].Par > 3)
                    return RedirectToPage("InputStats1");
                else
                    return RedirectToPage("InputStats2");
            }
            else
            {
                return RedirectToPage("InputStats4");
            }
        }

        public IActionResult OnPostScrambleOut()
        {
            MyStatSheet.ScrambleMiss++;
            MyStatSheet.TotalScrambleStrokes++;
            statistics.UpdateSheet(MyStatSheet);

            int id = UserRepository.Instance.Get().CurrentCourseId;
            if (courses.GetCourse(id).Holes.Count > UserRepository.Instance.Get().CurrentHolesFilled)
            {
                UserRepository.Instance.Get().CurrentHolesFilled++;

                // If the current holes par is more than 3, we go to the fairway. Otherwise, we skip the fairway shot.
                if (courses.GetCourse(id).Holes[UserRepository.Instance.Get().CurrentHolesFilled].Par > 3)
                    return RedirectToPage("InputStats1");
                else
                    return RedirectToPage("InputStats2");
            }
            else
            {
                return RedirectToPage("InputStats4");
            }
        }
    }
}
