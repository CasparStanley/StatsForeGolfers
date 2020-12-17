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
            Debug.WriteLine("GetAll OnGet");

            return Page();
        }

        public IActionResult OnPost()
        {
            Courses = courses.AllCourses();
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Courses = courses.FilterCourse(FilterCriteria);
            }
            Debug.WriteLine("GetAll OnPost");

            return Page();
        }

        public IActionResult OnPostUserCreate()
        {
            if (UserRepository.Instance.Get() != null)
            {
                Debug.WriteLine(UserRepository.Instance.Get().Name);
                Debug.WriteLine(UserRepository.Instance.Get().HomeClub);
                Debug.WriteLine("GetAllCOurses");
            }

            return Page();
        }
    }
}

