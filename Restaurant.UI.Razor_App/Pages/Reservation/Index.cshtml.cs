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

namespace Restaurant.UI.Razor_App.Pages.Reservation
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public IndexModel(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }

        public string UserId { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public BookingViewModel BookingList { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchBookingId { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            UserId = HttpContext.Session.GetString("userid");
            Username = HttpContext.Session.GetString("username");
            Token = HttpContext.Session.GetString("token");
            Role = HttpContext.Session.GetString("role");


            var client = _clientFactory.CreateClient("API_URL");
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            BookingList = await client.GetFromJsonAsync<BookingViewModel>("Booking");


            if (!String.IsNullOrEmpty(SearchBookingId))
            {
                var search = BookingList.Bookings.Where(x => x.Id == Convert.ToInt32(SearchBookingId)).FirstOrDefault();
                if(search != null)
                {
                    BookingList.Bookings = BookingList.Bookings.Where(i => i.Id == search.Id).ToList();
                }
            }
            return Page();
        }
    }
}
