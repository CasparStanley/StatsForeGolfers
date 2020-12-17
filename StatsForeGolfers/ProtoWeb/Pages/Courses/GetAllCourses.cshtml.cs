using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoWeb.Interfaces;
using ProtoWeb.Models;

namespace ProtoWeb.Pages.Courses
{
    public class GetAllCoursesModel : PageModel
    {
        private ICourses courses;

        public GetAllCoursesModel(ICourses repository)
        {
            courses = repository;
        }

        public Dictionary<int, Course> Courses { get; private set; }
        [BindProperty(SupportsGet = true)] public string FilterCriteria { get; set; }

        public IActionResult OnGet()
        {
            Courses = courses.AllCourses();
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Courses = courses.FilterCourse(FilterCriteria);
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            Courses = courses.AllCourses();
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Courses = courses.FilterCourse(FilterCriteria);
            }
            

            return Page();
        }
    }
}

