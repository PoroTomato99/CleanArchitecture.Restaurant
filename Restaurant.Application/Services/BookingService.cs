using Microsoft.AspNetCore.Http;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModel;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Models;
using Restaurant.Domain.ResponsesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepo _bookingRepo;
        public BookingService(IBookingRepo bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        public BookingViewModel CreateBooking(Domain.Models.Booking r)
        {
            var CreateBooking = _bookingRepo.CreateBooking(r);
            return new BookingViewModel()
            {
                Booking = CreateBooking,
                Response = new Response($"Create Booking Success", $"Successfully Created Booking for {CreateBooking.ReservationDate.ToShortDateString()}, {CreateBooking.ReservationTime}")
            };
        }

        public bool DeleteBooking(Domain.Models.Booking r)
        {
            throw new NotImplementedException();
        }

        public BookingViewModel GetBooking(int id)
        {
            throw new NotImplementedException();
        }

        public BookingViewModel GetBookings()
        {
            return new BookingViewModel()
            {
                Bookings = _bookingRepo.GetBookings()
            };
        }

        public BookingViewModel UpdateBooking(Domain.Models.Booking r)
        {
            var updateBooking = _bookingRepo.UpdateBooing(r);
            return new BookingViewModel()
            {
                Booking = updateBooking,
                Response = new("Update Booking", "Successfully Updated Booking")
            };
        }
    }
}
