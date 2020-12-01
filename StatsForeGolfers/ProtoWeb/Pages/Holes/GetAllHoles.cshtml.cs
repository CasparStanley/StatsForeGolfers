using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoWeb.Interfaces;
using ProtoWeb.Models;

namespace ProtoWeb.Pages.Holes
{
    public class GetAllHolesModel : PageModel
    {
        private IHoleRepository course;

        public GetAllHolesModel(IHoleRepository repository)
        {
            course = repository;
        }
        public Dictionary<int, Hole> Holes { get; private set; }
        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        public IActionResult OnGet()
        {
            Holes = course.AllHoles();
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Holes = course.FilterHole(FilterCriteria);
            }
            return Page();
        }
    }
}

