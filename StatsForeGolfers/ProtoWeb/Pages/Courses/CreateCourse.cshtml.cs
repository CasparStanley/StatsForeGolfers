using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoWeb.Interfaces;
using ProtoWeb.Models;
using ProtoWeb.Helpers;

namespace ProtoWeb.Pages.Courses
{
    public class CreateCourseModel : PageModel
    {
        [BindProperty]
        public Course CurrentCourse { get; set; }
        [BindProperty(SupportsGet = true)]
        public User CurrentUser { get; private set; }

        public ICourses courses;
        private IStatistics statistics;

        public CreateCourseModel(ICourses courseRepo, IStatistics statsRepo)
        {
            courses = courseRepo;
            statistics = statsRepo;

            CurrentUser = statistics.GetSheet().GolfPlayer;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public void OnPost(string status, string name, string club, int memberId, double hcp)
        {
            // Save sheet with new user data
            CurrentUser = new User()
            {
                Status = status,
                Name = name,
                HomeClub = club,
                MemberId = memberId,
                Handicap = hcp
            };

            statistics.UpdateSheet(statistics.GetSheet(), CurrentUser);

            Dictionary<int, Hole> holes = new Dictionary<int, Hole>();
            CurrentCourse.Holes = holes;
            try { courses.AddCourse(CurrentCourse); }
            catch { /*throw new ArgumentException("Couldn't add new course.");*/ }
        }
    }
}
