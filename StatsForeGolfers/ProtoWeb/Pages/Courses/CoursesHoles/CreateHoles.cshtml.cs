using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoWeb.Interfaces;
using ProtoWeb.Models;

namespace ProtoWeb.Pages.Courses.CoursesHoles
{
    public class CreateHolesModel : PageModel
    {
        [BindProperty]
        public Hole Hole { get; set; }
        public int CurrentCourseId { get; set; }

        private ICourses courses;
        public CreateHolesModel(ICourses repository)
        {
            courses = repository;
        }

        public IActionResult OnGet(int id)
        {
            CurrentCourseId = id;

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            courses.AddHole(Hole, id);

            return RedirectToPage("../GetAllCourses");
        }
    }
}
