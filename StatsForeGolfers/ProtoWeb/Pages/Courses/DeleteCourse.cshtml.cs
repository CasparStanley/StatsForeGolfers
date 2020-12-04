using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoWeb.Interfaces;
using ProtoWeb.Models;

namespace ProtoWeb.Pages.Courses
{
    public class DeleteCourseModel : PageModel
    {
        [BindProperty]
        public Course CurrentCourses { get; set; }

        private ICourses courses;

        public DeleteCourseModel(ICourses repository)
        {
            courses = repository;
        }

        public IActionResult OnGet(int id)
        {
            CurrentCourses = courses.GetCourse(id);
            return Page();
        }

        public IActionResult OnPost(Hole hole)
        {
            courses.DeleteCourse(CurrentCourses);
            return RedirectToPage("GetAllCourses");
        }
    }
}
