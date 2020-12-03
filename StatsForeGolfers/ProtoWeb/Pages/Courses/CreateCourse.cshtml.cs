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
    public class CreateCourseModel : PageModel
    {
        [BindProperty]
        public Course CurrentCourse { get; set; }
        
        public ICourses courses;
       
        public CreateCourseModel(ICourses repository)
        {
            courses = repository;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Dictionary<int, Hole> holes = new Dictionary<int, Hole>();
            CurrentCourse.Holes = holes;
            courses.AddCourse(CurrentCourse);

            return RedirectToPage("GetAllCourses");
        }
    }
}
