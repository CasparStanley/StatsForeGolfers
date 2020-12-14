using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoWeb.Models;
using ProtoWeb.Interfaces;

namespace ProtoWeb.Users
{
    public class UserModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public User CurrentUser { get; set; }

        private IStatistics statistics;

        public UserModel (IStatistics statsRepo)
        {
            statistics = statsRepo;

            // TO CREATE A NEW SHEET EVERY TIME WE START THE PROGRAM.
            statistics.CreateSheet(new StatSheet(CurrentUser));
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

            return Page();
        }
    }
}
