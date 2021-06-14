using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Application.ViewModel;
using Restaurant.Domain.AuthenticationModel;

namespace Restaurant.UI.Razor_App.Pages.Restaurants.Owner
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public IndexModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public string Success { get; set; }
        public string Error { get; set; }

        public string Token { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public RestaurantViewModel RestaurantView { get; set; }
        public async Task<IActionResult> OnGetAsync(string success, string error)
        {
            Token = HttpContext.Session.GetString("token");
            if(Token == null)
            {
                return RedirectToPage("/Authentication/Index", new { error = "Login Required", success = "" });
            }
            Role = HttpContext.Session.GetString("role");
            if(Role != UserRoles.Owner)
            {
                return RedirectToPage("/Reservation/Index");
            }

            var client = _clientFactory.CreateClient("API_URL");
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            try
            {
                RestaurantView = await client.GetFromJsonAsync<RestaurantViewModel>("Restaurant");
            }
            catch (Exception ex)
            {
                return RedirectToPage("/ErrorHandler/Response", new { responses = $"{ex.GetType()}:{ex.Message}" });
            }

            Success = success;
            Error = error;
            Username = HttpContext.Session.GetString("username");
            UserId = HttpContext.Session.GetString("userid");
            RestaurantView.Restaurants = RestaurantView.Restaurants.Where(y => y.UserId == UserId).ToList();
            return Page();

        }
    }
}
