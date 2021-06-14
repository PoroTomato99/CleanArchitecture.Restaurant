using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Restaurant.UI.Razor_App.Pages.Authentication
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Remove("token");
            HttpContext.Session.Remove("userid");
            HttpContext.Session.Remove("role");
            HttpContext.Session.Remove("username");
            HttpContext.Session.Clear();
            return RedirectToPage("./Index");
        }
    }
}
