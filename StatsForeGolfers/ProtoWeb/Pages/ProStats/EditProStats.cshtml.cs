using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoWeb.Models;

namespace ProtoWeb.Pages.ProStats
{
    public class EditProStatsModel : PageModel
    {
        private ProStatsRepository repo;

        [BindProperty]
        public Models.ProStats ProStats { get; set; }

        public EditProStatsModel()
        {
            repo = ProStatsRepository.Instance;
        }
        public IActionResult OnGet(int id)
        {
            ProStats = repo.GetProStats(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) {
                return Page();
            }
            repo.UpdateProStats(ProStats);
            return RedirectToPage("ProStatistics");
        }
    }
}
