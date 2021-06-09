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
using Restaurant.Domain.ResponsesModels;

namespace Restaurant.UI.Razor_App.Pages.Restaurants
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public IndexModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public RestaurantViewModel RestaurantView { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
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
            return Page();
        }

        public async Task<PartialViewResult> OnGetRestaurantPartial()
        {
            var client = _clientFactory.CreateClient("API_URL");
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            try
            {
                RestaurantView = await client.GetFromJsonAsync<RestaurantViewModel>("Restaurant");
                return Partial("Restaurants/_restaurantList", RestaurantView);
            }
            catch (Exception ex)
            {
                var error = new RestaurantViewModel()
                {
                    Response = new Response(ex.GetType().ToString(), ex.Message)
                };
                return Partial("Restaurant/_partialError", error);
            }
        }
    }
}
