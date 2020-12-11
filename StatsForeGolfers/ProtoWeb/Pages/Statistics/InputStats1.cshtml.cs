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
        public StatSheet MockSheet { get; private set; }

        public InputStats1Model(IStatistics statsRepo, ICourses courseRepo)
        {
            statistics = statsRepo;
            courses = courseRepo;

            statistics.CreateSheet(new StatSheet());
            MockSheet = statistics.GetSheet();
        }

        public Course CurrentCourse { get; private set; }
        public Dictionary<int, Hole> Holes { get; private set; }

        public IActionResult OnGet()
        {
            CurrentCourse = courses.GetCourse(1);
            Holes = courses.AllHoles(1);

            //MockSheet = statistics.GetSheet();

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            switch(id)
            {
                case 0:
                    {
                        MockSheet.FairWayMissLeft++;
                        break;
                    }
                case 1:
                    {
                        MockSheet.FairWayHit++;
                        break;
                    }
                case 2:
                    {
                        MockSheet.FairWayMissRight++;
                        break;
                    }
                default:
                    {
                        // Error
                        break;
                    }
            }

            statistics.UpdateSheet(MockSheet);
            return RedirectToPage("/Statistics/InputStats2");
        }
    }
}
