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
    public class CreateHoleModel : PageModel
    {
        [BindProperty]
        public Hole CurrentHole { get; set; }
        private IHoleRepository course;

        public CreateHoleModel(IHoleRepository repository)
        {
            course = repository;
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
            course.AddHole(CurrentHole);
            return RedirectToPage("../GetAllHoles");
        }
    }
}