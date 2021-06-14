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
using Restaurant.Domain.Models;
using Restaurant.Domain.ResponsesModels;

namespace Restaurant.UI.Razor_App.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public DetailsModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [BindProperty]
        public RestaurantViewModel RestaurantDetail { get; set; }
        public RestaurantFollowerView FollowerDetails { get; set; }
        public List<string> TimeList { get; set; }


        public string UserId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }

        public string Success { get; set; }
        public string Error { get; set; }
        public async Task<IActionResult> OnGet(int? id, string success, string error)
        {

            if (id == null)
            {
                return Partial("Restaurants/_partialError");
            }
            var client = _clientFactory.CreateClient("API_URL");
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            try
            {
                RestaurantDetail = await client.GetFromJsonAsync<RestaurantViewModel>("Restaurant/" + id);
            }
            catch (Exception ex)
            {
                var response = new RestaurantViewModel()
                {
                    Response = new($"Error", $"{ex.Message}")
                };

                return Partial("Restaurants/_partialError", response);
            }

            try
            {
                FollowerDetails = await client.GetFromJsonAsync<RestaurantFollowerView>("restaurant/restaurant-follower-details/"+id);
            }
            catch (Exception ex)
            {
                var response = new Response()
                {
                    Type = $"{ex.GetType()}",
                    Message = $"{ex.Message}"
                };
                return Partial("Restaurants/_partialError", response);
            }


            var openHour = TimeSpan.Parse(RestaurantDetail.Restaurant.OpenHour);
            var endHour = TimeSpan.Parse(RestaurantDetail.Restaurant.EndHour);

            var timeList = new List<string>();
            var oneHour = TimeSpan.FromHours(1);
            //convert open and end hour to timespan, then take end minus open to get duration in between
            var openDuration = endHour - openHour;
            while (openDuration > TimeSpan.Parse("01:00:00"))
            {
                timeList.Add(openHour.ToString());
                openHour += oneHour;
                openDuration -= oneHour;
            }


            UserId = HttpContext.Session.GetString("userid");
            Success = success;
            Error = error;
            TimeList = timeList;
            //return Partial("Restaurants/_restaurantsDetails", RestaurantDetail);
            return Page();
        }

        [BindProperty]
        public RestaurantFollower Unfollow { get; set; }
        public async Task<IActionResult> OnPostUnfollow()
        {
            if(Unfollow == null)
            {
                return Partial("/Restaurants/_partialError");
            }

            var client = _clientFactory.CreateClient("API_URL");
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            try
            {
                var unfollow = await client.DeleteAsync("restaurant/unfollow/" + Unfollow.Id);
                if (unfollow.IsSuccessStatusCode)
                {
                    var success = unfollow.Content.ReadFromJsonAsync<RestaurantFollowerView>().Result;
                    return RedirectToPage("./Details", new { Id = Unfollow.RestaurantId, success = $"{success.Response.Message}", error = "" });
                }
                else
                {
                    var error = unfollow.Content.ReadFromJsonAsync<RestaurantFollowerView>().Result;
                    return RedirectToPage("./Details", new { Id = Unfollow.RestaurantId, success = "", error = $"{error.Response.Message}" });
                }
            }
            catch (Exception ex)
            { 
                return Partial("/Restaurants/_partialError");
            }
        }


        [BindProperty]
        public RestaurantFollower Follow { get; set; }
        public async Task<IActionResult> OnPostFollow()
        {
            if (Follow == null)
            {
                return Partial("/Restaurants/_partialError");
            }

            var client = _clientFactory.CreateClient("API_URL");
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            try
            {
                var followRestaurant = await client.PostAsJsonAsync("restaurant/follow-restaurant", Follow);
                if (followRestaurant.IsSuccessStatusCode)
                {
                    var success = followRestaurant.Content.ReadFromJsonAsync<RestaurantFollowerView>().Result;
                    return RedirectToPage("./Details", new { Id = Follow.RestaurantId, success = $"{success.Response.Message}", error = "" });
                }
                else
                {
                    var error = followRestaurant.Content.ReadFromJsonAsync<RestaurantFollowerView>().Result;
                    return RedirectToPage("./Details", new { Id = Follow.RestaurantId, success = "", error = $"{error.Response.Message}" });
                }
            }
            catch (Exception ex)
            {
                return Partial("/Restaurants/_partialError");
            }
        }





        [BindProperty]
        public Booking Reservation { get; set; }
        public async Task<IActionResult> OnPost()
        { 
            if(Reservation == null)
            {
                return Partial("/Restaurants/_partialError");

            }
            var client = _clientFactory.CreateClient("API_URL");
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            try
            {
                var CreateBooking = await client.PostAsJsonAsync("Booking", Reservation);
                if (CreateBooking.IsSuccessStatusCode)
                {
                    var success_result = CreateBooking.Content.ReadFromJsonAsync<BookingViewModel>().Result;
                    return Partial("Restaurants/_success_book", success_result);
                }
                else
                {
                    var error_result = CreateBooking.Content.ReadFromJsonAsync<BookingViewModel>().Result;
                    
                    return Partial("Restaurants/_bookingError", error_result);
                }
            }
            catch (Exception ex)
            {
                var Response = new RestaurantViewModel()
                {
                    Response = new Response(ex.GetType().ToString(), ex.Message)
                };
                return Partial("Restaurants/_partialError", Response);
            }
           
        }
    }
}
