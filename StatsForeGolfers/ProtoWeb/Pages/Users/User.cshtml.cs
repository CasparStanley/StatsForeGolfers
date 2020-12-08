using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoWeb.Models;

namespace ProtoWeb.Users
{
    public class UserModel : PageModel
    {
        [BindProperty]
        public User CurrentUser { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // ADD INPUT TO A NEW USER OBJECT HERE
            //return RedirectToPage("../Courses/CreateCourse");
            return Page();
        }
    }
}
