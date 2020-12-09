using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProtoWeb.Pages.Statistics
{
    public class InputStats2Model : PageModel
    {
        [BindProperty]
        public StatSheet StatSheet { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
