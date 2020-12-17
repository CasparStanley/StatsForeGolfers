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
    public class SelectCourseModel : PageModel
    {
        private IStatistics statistics;
        private ICourses courses;

        public SelectCourseModel(IStatistics statsRepo, ICourses repository)
        {
            statistics = statsRepo;
            courses = repository;

            // TO CREATE A NEW SHEET EVERY TIME WE START THE PROGRAM.
            statistics.CreateSheet(new StatSheet());
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

        public IActionResult OnPostSelectCourse(int id)
        {
            UserRepository.Instance.Get().CurrentCourseId = id;
            UserRepository.Instance.Get().CurrentHolesFilled = 1;

            // If the current holes par is more than 3, we go to the fairway. Otherwise, we skip the fairway shot.
            if (courses.GetCourse(id).Holes[UserRepository.Instance.Get().CurrentHolesFilled].Par > 3)
                return RedirectToPage("/Statistics/InputStats1");
            else
                return RedirectToPage("/Statistics/InputStats2");
        }
    }
}

