using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Restaurant.UI.Razor_App.Pages.Demo
{
    public class PartialDemoModel : PageModel
    {
            public List<string> Animals = new List<string>();
            public void OnGet()
            {
                Animals.AddRange(new[] { "Antelope", "Badger", "Cat", "Dog" });
            }
    }
}
