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
    public class EditHoleModel : PageModel
    {
        [BindProperty]
        public Hole Hole { get; set; }

        private IHoleRepository course;

        public EditHoleModel(IHoleRepository repository)
        {
            course = repository;
        }
        public void OnGet(int holeNo)
        {
            Hole = course.GetHole(holeNo);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            course.UpdateHole(Hole);
            return RedirectToPage("GetAllHoles");
        }
    }
}

