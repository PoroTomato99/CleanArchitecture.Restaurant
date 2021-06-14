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
    public class DetailModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public DetailModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        public string Token { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public RestaurantViewModel RestaurantDetails { get; set; }
        public BookingViewModel BookingList { get; set; }

        public string Success { get; set; }
        public string Error { get; set; }
        public async Task<IActionResult> OnGet(int? id, string success, string error)
        {

            Token = HttpContext.Session.GetString("token");
            if (Token == null)
            {
                return RedirectToPage("/Authentication/Index", new { error = "Login Required", success = "" });
            }
            Role = HttpContext.Session.GetString("role");
            if (Role != UserRoles.Owner)
            {
                return RedirectToPage("/Reservation/Index");
            }

            if(id == null)
            {
                return RedirectToPage("./index");
            }

            var client = _clientFactory.CreateClient("API_URL");
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));


            try
            {
                RestaurantDetails =await client.GetFromJsonAsync<RestaurantViewModel>("Restaurant/" + id);
                BookingList = await client.GetFromJsonAsync<BookingViewModel>("Booking");
            }
            catch (Exception ex)
            {
                //log error
                return Partial("CreateOwner/_RazorExceptionError");
            }

            
            Success = success;
            Error = error;

            return Page();
        }

        [BindProperty]
        public Domain.Models.Booking UpdateBooking { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            var client = _clientFactory.CreateClient("API_URL");
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            try
            {
                var processBooking = await client.PutAsJsonAsync("Booking/" + UpdateBooking.Id, UpdateBooking);
                if (!processBooking.IsSuccessStatusCode)
                {
                    var error = processBooking.Content.ReadFromJsonAsync<BookingViewModel>().Result;
                    return RedirectToPage("./Detail", new { id = UpdateBooking.Id, success = "", error = $"{error.Response.Message}" });
                }
                else
                {
                    var success = processBooking.Content.ReadFromJsonAsync<BookingViewModel>().Result;
                    return RedirectToPage("./Detail", new { id = UpdateBooking.Id, success = $"{success.Response.Message}", error = "" });
                }
            }
            catch (Exception ex)
            {
                return Partial("/CreateOwner/_RazorExceptionError");
            }
        }
    }
}
