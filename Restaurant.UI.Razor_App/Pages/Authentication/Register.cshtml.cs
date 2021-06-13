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

namespace Restaurant.UI.Razor_App.Pages.Authentication
{
    public class RegisterModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _clientFactory;

        public RegisterModel(IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }

        public AuthenticationViewModel ResgisterResponse { get; set; }
        public string ErrorResponse { get; set; }
        public string SuccessResponse { get; set; }
        public IActionResult OnGet(string responseMessage, string successResponse)
        {
            ErrorResponse = responseMessage;
            SuccessResponse = successResponse;
            return Page();
        }


        [BindProperty]
        public Register_Admin CustomerForm { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if(CustomerForm != null)
            {
                Console.WriteLine("Customer Form is not Null");
            }

            var client = _clientFactory.CreateClient("API_URL");
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            try
            {
                var CreateCustomer = await client.PostAsJsonAsync("Authentication/customer", CustomerForm);
                if (!CreateCustomer.IsSuccessStatusCode)
                {
                    return RedirectToPage("./register", new { responseMessage = "Registration Unsuccessfull", successResponse = ""});
                }
                var CustomerData = CreateCustomer.Content.ReadFromJsonAsync<AuthenticationViewModel>().Result;
                return RedirectToPage("./Index", new { error ="", success = $"Successfully Created {CustomerData.Profile.Username}'s Account" });
            }
            catch (Exception ex)
            {
                //log the exception Error
                return RedirectToPage("./Register", new { responseMessage = "Oops Something Went Wrong. Try Again Later!.", successReponse = ""});
            }
            
        }
    }
}
