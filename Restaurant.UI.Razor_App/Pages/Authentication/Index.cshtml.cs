using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Restaurant.Application.ViewModel;
using Restaurant.Domain.AuthenticationModel;

namespace Restaurant.UI.Razor_App.Pages.Authentication
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _clientFactory;
        public IndexModel(IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            _configuration = configuration;
            _clientFactory = clientFactory;
        }

        [BindProperty]
        public Login_Model LoginModel { get; set; }
        public string Error {get;set;}
        public string Success { get; set; }
        public string SessionToken { get; set; }
        public IActionResult OnGet(string error, string success)
        {
            var token = HttpContext.Session.GetString("token");
            if (token != null)
            {
                return RedirectToPage("/Reservation/index");
            }
            Success = success;
            Error = error;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var client = _clientFactory.CreateClient("API_URL");
            if (LoginModel == null)
            {
                return RedirectToPage("./Index");
            }

            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("Authentication/login", LoginModel);
                if (response.IsSuccessStatusCode)
                {
                    var login_data = response.Content.ReadFromJsonAsync<AuthenticationViewModel>().Result;
                    var token = login_data.Token;
                    HttpContext.Session.SetString("token", token);


                    var user = login_data.Profile;
                    //set customer id
                    HttpContext.Session.SetString("userid", user.UserId);
                    HttpContext.Session.SetString("username", user.Username);
                   
                    var role = user.Roles;

                    if(role.Contains(UserRoles.Customer) && role.Contains(UserRoles.Owner))
                    {
                        HttpContext.Session.SetString("role", UserRoles.Owner);
                        return RedirectToPage("/Restaurants/Owner/Index");
                    }
                    //set customer role
                    if(role.Any(x => x == UserRoles.Customer))
                    {
                        HttpContext.Session.SetString("role", UserRoles.Customer);
                        return RedirectToPage("/Reservation/Index");
                    }
                    
                    //set employee role
                    else if(role.Any(x => x == UserRoles.Employee))
                    {
                        HttpContext.Session.SetString("role", UserRoles.Employee);
                        return RedirectToPage("/Reservation/Index");
                    } 
                    
                    //set Restaurant owner role
                    else if(role.Any(x => x == UserRoles.Owner))
                    {
                        HttpContext.Session.SetString("role", UserRoles.Owner);
                        return RedirectToPage("/Restaurants/Owner/Index");
                    }

                    //set admin role
                    else
                    {
                        HttpContext.Session.SetString("role", UserRoles.Admin);
                        return RedirectToPage("/Reservation/Index");
                    }
                }
                else
                {
                    var errorData = response.Content.ReadFromJsonAsync<AuthenticationViewModel>().Result.Response.Message;
                    return RedirectToPage("./Index", new { error = errorData, success = "" });
                }

            }
            catch (Exception ex)
            {
                return RedirectToPage("./Index", new { error = $"{ex.InnerException.Message}", success=""});
                //return RedirectToPage("/ErrorHandler/Response", new { result = ex.Message.ToString() });
            }
        }
    }
}
