using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModel;
using Restaurant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        //dependency injection
        private readonly IBookingService _service;
        public BookingController(IBookingService bookingService)
        {
            _service = bookingService;
        }

        // GET: api/<BookingController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                BookingViewModel bookings = _service.GetBookings();
                if (bookings.Bookings == null)
                {
                    return NotFound();
                }
                return Ok(bookings);
            }
            catch (Exception e)
            {

                var response = new Domain.ResponsesModels.Response(type: e.GetType().ToString(), e.Message);
                return Conflict(new BookingViewModel()
                {
                    Response = response
                });
            }
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookingController>
        [HttpPost]
        public IActionResult Post([FromBody] Booking reservation)
        {
            try
            {
                var CreateBooking = _service.CreateBooking(reservation);
                return Ok(CreateBooking);
            }
            catch (Exception ex)
            {
                return Conflict(new BookingViewModel()
                {
                    Response = new(ex.GetType().ToString(), ex.Message)
                });
            }
        }

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
