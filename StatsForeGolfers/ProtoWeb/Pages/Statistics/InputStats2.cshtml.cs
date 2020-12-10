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

        public InputStats2Model(IStatistics statsRepo, ICourses courseRepo)
        {
            statistics = statsRepo;
            courses = courseRepo;
        }

        public Course CurrentCourse { get; private set; }
        public Dictionary<int, Hole> Holes { get; private set; }
        [BindProperty]
        public StatSheet MockSheet { get; private set; }

        public IActionResult OnGet()
        {
            CurrentCourse = courses.GetCourse(1);
            Holes = courses.AllHoles(1);
            MockSheet = statistics.Sheet();
            
            return Page();
        }

        public void OnPost()
        {
        }
    }
}
