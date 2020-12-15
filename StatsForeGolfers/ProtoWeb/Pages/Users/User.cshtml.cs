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
        public User UserData { get; set; }

        public IActionResult OnPost()
        {
            UserRepository.Instance.Add(UserData);
            
            if (UserRepository.Instance.Get() != null)
            {
                Debug.WriteLine(UserRepository.Instance.Get().Name);
                Debug.WriteLine(UserRepository.Instance.Get().HomeClub);
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            //return RedirectToPage("../Courses/CreateCourse");
            return Page();
        }
    }
}
