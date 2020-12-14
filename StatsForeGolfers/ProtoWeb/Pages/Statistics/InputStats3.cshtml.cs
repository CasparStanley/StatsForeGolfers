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

        public InputStats3Model(IStatistics statsRepo, ICourses courseRepo)
        {
            statistics = statsRepo;
            courses = courseRepo;

            MyStatSheet = statistics.GetSheet();
        }

        public Course CurrentCourse { get; private set; }
        public Dictionary<int, Hole> Holes { get; private set; }

        public IActionResult OnGet()
        {
            CurrentCourse = courses.GetCourse(1);
            Holes = courses.AllHoles(1);

            return Page();
        }

        public void OnPost(int btnId)
        {
            CurrentCourse = courses.GetCourse(1);
            Holes = courses.AllHoles(1);

            switch (btnId)
            {
                case 0:
                    {
                        MyStatSheet.GreenMissLeft++;
                        break;
                    }
                case 1:
                    {
                        MyStatSheet.GreenHit++;
                        break;
                    }
                case 2:
                    {
                        MyStatSheet.GreenMissRight++;
                        break;
                    }
                default:
                    {
                        // Error
                        break;
                    }
            }

            MyStatSheet.TotalGreenStrokes++;

            statistics.UpdateSheet(MyStatSheet, statistics.GetSheet().GolfPlayer);
        }
    }
}
