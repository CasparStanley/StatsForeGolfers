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
    public class EditCourseModel : PageModel
    {
        [BindProperty]
        public Course CurrentCourse { get; set; }

        private ICourses courses;

        public EditCourseModel(ICourses repository)
        {
            courses = repository;
        }
        public void OnGet(int id)
        {
            CurrentCourse = courses.GetCourse(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            courses.UpdateCourse(CurrentCourse);
            return RedirectToPage("GetAllCourses");
        }
    }
}
