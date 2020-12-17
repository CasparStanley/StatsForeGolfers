using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoWeb.Interfaces;
using ProtoWeb.Models;

namespace ProtoWeb.Pages.Courses.CoursesHoles
{
    public class DeleteHoleModel : PageModel
    {
        private ICourses courses;
        [BindProperty] 
        public Hole Hole { get; set; }
        public int CurrentCourseId { get; set; }

        public DeleteHoleModel(ICourses repository)
        {
            courses = repository;
        }
        
        public IActionResult OnGet(int holeNo,int id)
        {
            Dictionary<int, Hole> holes = courses.AllHoles(id);
            Hole = holes[holeNo];
            CurrentCourseId = id;

            return Page();
        }

        public IActionResult OnPost(Hole hole, int id)
        {
            courses.DeleteHole(hole,id);
            return RedirectToPage("../GetAllCourses");
        }
    }
}
