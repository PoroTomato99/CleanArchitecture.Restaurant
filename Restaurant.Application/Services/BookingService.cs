using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModel;
using Restaurant.Domain.Interfaces;
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

        public BookingViewModel CreateRestaurant(Domain.Models.Restaurant r)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRestaurant(Domain.Models.Restaurant r)
        {
            throw new NotImplementedException();
        }

        public BookingViewModel GetRestaurant(int id)
        {
            throw new NotImplementedException();
        }

        public BookingViewModel GetRestaurants()
        {
            return new BookingViewModel()
            {
                Bookings = _bookingRepo.GetBookings()
            };
        }

        public BookingViewModel UpdateRestaurant(Domain.Models.Restaurant r)
        {
            throw new NotImplementedException();
        }
    }
}
