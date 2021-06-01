using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Models;
using Restaurant.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Data.Repositories
{
    public class BookingRepo : IBookingRepo
    {

        private readonly Restaurant_CleanArchitectureContext _context;
        public BookingRepo(Restaurant_CleanArchitectureContext context)
        {
            _context = context;
        }

        public Booking CreateBooking(Booking x)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBooking(Booking x)
        {
            throw new NotImplementedException();
        }

        public Booking GetBooking(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Booking> GetBookings()
        {
            return _context.Bookings;
        }

        public bool IsBookingExist(Booking x)
        {
            throw new NotImplementedException();
        }

        public Booking UpdateBooing(Booking x)
        {
            throw new NotImplementedException();
        }
    }
}
