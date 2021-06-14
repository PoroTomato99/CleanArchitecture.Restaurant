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

namespace Restaurant.UI.Razor_App.Pages.Admin
{
    public class UserDetailModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _clientFactory;
        public UserDetailModel(IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            _configuration = configuration;
            _clientFactory = clientFactory;
        }

        public string Token { get; set; }
        public string Username { get; set; }
        public string UserId { get; set; }
        public string Role { get; set; }

        public UserDetailsView ProfileDetails { get; set; }
        public async Task<IActionResult> OnGetAync(string username)
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

            ProfileDetails = await client.GetFromJsonAsync<UserDetailsView>("authentication/user-detail/"+username);
            return Page();
        }


        [BindProperty]
        public UserProfile ApproveRole { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            var client = _clientFactory.CreateClient("API_URL");
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            try
            {
                var updateRole = await client.PostAsJsonAsync("authentication/admin/approve-role", ApproveRole);
                if (!updateRole.IsSuccessStatusCode)
                {
                    var error = updateRole.Content.ReadFromJsonAsync<AuthenticationViewModel>().Result;
                    return RedirectToPage("./index", new { success = "", error = $"{error.Response.Message}" });
                }
                else
                {
                    var success = updateRole.Content.ReadFromJsonAsync<AuthenticationViewModel>().Result;
                    return RedirectToPage("./index", new { success = $"{success.Response.Message}", error = "" });
                }
            }
            catch (Exception ex)
            {
                //log error ex
                return RedirectToPage("./index", new { success = "", error = "Oops Somethings Wrong!" });
            }
        }

    }
}
