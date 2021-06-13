using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Restaurant.Domain.AuthenticationModel;
using Restaurant.Domain.Models;

namespace Restaurant.UI.Razor_App.Pages.Authentication.Owner
{
    public class CreateRestaurantModel : PageModel
    {

        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _clientFactory;
        public CreateRestaurantModel(IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            _configuration = configuration;
            _clientFactory = clientFactory;
        }


        public string Token { get; set; }
        public string Role { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }

        public List<string> RestaurantType { get; set; }
        public IActionResult OnGet()
        {
            Token = HttpContext.Session.GetString("token");
            Role = HttpContext.Session.GetString("role");
            UserId = HttpContext.Session.GetString("userid");
            Username = HttpContext.Session.GetString("username");

            if(Token == null)
            {
                return RedirectToPage("/Authentication/Index", new { onPostMessage = "Login Required"});
            }

            RestaurantType = Type_Restaurant.RestaurantTypes();
            return Page();
        }

        [BindProperty]
        public Domain.Models.Restaurant RestaurantForm { get; set; }
        public async Task<IActionResult> OnPostCreateRestaurant()
        {
            if(RestaurantForm != null)
            {
                Console.WriteLine("Restaurant Form NOT NUll");
            }
            else
            {
                Console.WriteLine("Error : Null Restaurant Form");
            }
            return RedirectToPage("/Authentication/Index");
        }

        [BindProperty]
        public UserProfile OwnerForm { get; set; }
        public async Task<IActionResult> OnPostCreateOwner()
        {
            if(OwnerForm!= null)
            {
                Console.WriteLine("Owner form not null");
            }
            else
            {
                Console.WriteLine("Owner form is null");
            }
            return RedirectToPage("/Authentication/Index");
        }
    }
}
