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


        public string Success { get; set; }
        public string Error { get; set; }
        public List<string> RestaurantType { get; set; }
        public IActionResult OnGet(string success, string error)
        {
            Token = HttpContext.Session.GetString("token");
            Role = HttpContext.Session.GetString("role");
            UserId = HttpContext.Session.GetString("userid");
            Username = HttpContext.Session.GetString("username");

            if(Token == null)
            {
                return RedirectToPage("/Authentication/Index", new { onPostMessage = "Login Required"});
            }


            Success = success;
            Error = error;
            RestaurantType = Type_Restaurant.RestaurantTypes();
            return Page();
        }

        [BindProperty]
        public Domain.Models.Restaurant RestaurantForm { get; set; }
        public async Task<IActionResult> OnPostCreateRestaurant()
        {
            var client = _clientFactory.CreateClient("API_URL");
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            try
            {
                var SubmitRestaurnat = await client.PostAsJsonAsync("Restaurant", RestaurantForm);
                if (!SubmitRestaurnat.IsSuccessStatusCode)
                {
                    var error = SubmitRestaurnat.Content.ReadFromJsonAsync<RestaurantViewModel>().Result;
                    return RedirectToPage("./CreateRestaurant", new { success = "", error = $"{error.Response.Message}" });
                }
                else
                {
                    var success = SubmitRestaurnat.Content.ReadFromJsonAsync<RestaurantViewModel>().Result;
                    return RedirectToPage("./CreateRestaurant", new { success = $"{success.Response.Message}", error = "" });
                }
            }
            catch (Exception ex)
            {

                return Partial("/CreateOwner/_RazorExceptionError");
            }
        }

        [BindProperty]
        public UserProfile OwnerForm { get; set; }
        public async Task<IActionResult> OnPostCreateOwner()
        {

            var client = _clientFactory.CreateClient("API_URL");
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            try
            {
                var RoleRequest = await client.PostAsJsonAsync("Authentication/customer/request-role", OwnerForm);
                if (!RoleRequest.IsSuccessStatusCode)
                {
                    var error = RoleRequest.Content.ReadFromJsonAsync<AdminViewModel>().Result;
                    return RedirectToPage("./CreateRestaurant", new { success = "", error = $"{error.ApiResponse.Message}"});
                }
                else
                {
                    var success = RoleRequest.Content.ReadFromJsonAsync<AdminViewModel>().Result;
                    return RedirectToPage("./createRestaurant", new { success = $"{success.ApiResponse.Message}", error = ""});
                }
            }
            catch (Exception ex)
            {
                //log the error
                return Partial("/CreateOwner/_RazorExceptionError");
            }
        }
    }
}
