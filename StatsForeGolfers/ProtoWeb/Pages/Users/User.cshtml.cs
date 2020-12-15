using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Debug.WriteLine(CurrentUser.Name);
            Debug.WriteLine(CurrentUser.HomeClub);
            Debug.WriteLine(CurrentUser.Handicap);
            Debug.WriteLine(CurrentUser.MemberId);
            Debug.WriteLine(CurrentUser.Status);
            // ADD INPUT TO A NEW USER OBJECT HERE
            //User newUser = new User();
            //CurrentUser = newUser;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            //return RedirectToPage("../Courses/CreateCourse");
            return Page();
        }
    }
}
