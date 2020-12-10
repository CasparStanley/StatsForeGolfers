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
    public class GetAllHolesModel : PageModel
    {
       [BindProperty]
        public Course Course { get; set; }
        public int courseId { get; set; }

        private ICourses courses;

        public GetAllHolesModel(ICourses repository)
        {
            courses = repository;
        }
        public Dictionary<int,Hole> Holes { get; private set; }

        public void OnGet(int id)
        {
            Holes = courses.AllHoles(id);
            courseId = id;
        }
    }
}
