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
    public class DeleteHoleModel : PageModel
    {
        [BindProperty]
        public Hole Hole { get; set; }

        private IHoleRepository course;

        public DeleteHoleModel(IHoleRepository repository)
        {
            course = repository;
        }

        public IActionResult OnGet(int holeNo)
        {
            Hole = course.GetHole(holeNo);
            return Page();
        }

        public IActionResult OnPost(Hole hole)
        {
            course.DeleteHole(hole);
            return RedirectToPage("GetAllHoles");
        }
    }
}
