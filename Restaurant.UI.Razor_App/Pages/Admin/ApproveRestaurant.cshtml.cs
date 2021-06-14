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
using Microsoft.Extensions.Configuration;
using Restaurant.Application.ViewModel;
using Restaurant.Domain.AuthenticationModel;

namespace Restaurant.UI.Razor_App.Pages.Admin
{
    public class ApproveRestaurantModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _clientFactory;
        public ApproveRestaurantModel(IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            _configuration = configuration;
            _clientFactory = clientFactory;
        }


        public string Token { get; set; }
        public string Username { get; set; }
        public string UserId { get; set; }
        public string Role { get; set; }

        public string Success { get; set; }
        public string Error { get; set; }

        public RestaurantViewModel RestaurantRequest { get; set; }
        public async Task<IActionResult> OnGetAsync(string success, string error)
        {
            var client = _clientFactory.CreateClient("API_URL");
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            Token = HttpContext.Session.GetString("token");
            Username = HttpContext.Session.GetString("username");
            UserId = HttpContext.Session.GetString("userid");
            Role = HttpContext.Session.GetString("role");
            if (Token == null)
            {
                return RedirectToPage("/Authentication/Index", new { error = $"Admin Login Required", success = "" });
            }
            if (Role != UserRoles.Admin)
            {
                return RedirectToPage("/Reservation/Index");
            }
            try
            {
                RestaurantRequest = await client.GetFromJsonAsync<RestaurantViewModel>("Restaurant");
            }
            catch (Exception ex)
            {
                return Partial("/CreateOwner/_RazorExceptionError");
            }
           
            Success = success;
            Error = error;
            return Page();
        }

        [BindProperty]
        public Domain.Models.Restaurant ApproveRestaurant { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            var client = _clientFactory.CreateClient("API_URL");
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            try
            {
                var updateRestaurant = await client.PutAsJsonAsync("Restaurant/" + ApproveRestaurant.Id, ApproveRestaurant);
                if (updateRestaurant.IsSuccessStatusCode)
                {
                    var success = updateRestaurant.Content.ReadFromJsonAsync<RestaurantViewModel>().Result;
                    return RedirectToPage("./ApproveRestaurant", new { success = $"{success.Response.Message}", error ="" });
                }
                else
                {
                    var error = updateRestaurant.Content.ReadFromJsonAsync<RestaurantViewModel>().Result;
                    return RedirectToPage("./ApproveRestaurant", new { success = "", error = $"{error.Response.Message}" });
                }
            }
            catch (Exception ex)
            {
                return Partial("/CreateOwner/_RazorExceptionError");
            }
        }
    }
}
