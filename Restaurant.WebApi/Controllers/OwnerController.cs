using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IRestaurantService _restaurant;
        private readonly IBookingService _booking;
        public OwnerController(IRestaurantService restaurant)
        {
            _restaurant = restaurant;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var bookingView = _booking.GetBookings();
            var rest_booking = bookingView.Bookings.Where(x => x.RestaurantId == id).ToList();

            try
            {
                return Ok(new OwnerRestaurantView()
                {
                    Restaurant = _restaurant.GetRestaurant(id).Restaurant,
                    Bookings = rest_booking
                });
            }
            catch (Exception ex)
            {
                return Conflict(new OwnerRestaurantView()
                {
                    Response = new($"{ex.GetType()}", $"{ex.Message}")
                }); ; ;
            }

        }
    }
}
