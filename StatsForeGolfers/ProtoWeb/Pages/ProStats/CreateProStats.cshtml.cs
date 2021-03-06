using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoWeb.Models;

namespace ProtoWeb.Pages.ProStats
{
    public class CreateProStatsModel : PageModel
    {
        private ProStatsRepository repo;

        [BindProperty]
        public Models.ProStats ProStats { get; set; }

        public CreateProStatsModel()
        {
            
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) {
                return Page();
            }
            ProStatsRepository.Instance.AddProStats(ProStats);
            return RedirectToPage("ProStatistics");
        }
    }
}
