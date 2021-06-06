using Restaurant.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Interfaces
{
    public interface IBookingService
    {
        BookingViewModel GetBookings();
        BookingViewModel GetBooking(int id);
        BookingViewModel CreateBooking(Domain.Models.Booking r);
        BookingViewModel UpdateBooking(Domain.Models.Booking r);
        Boolean DeleteBooking(Domain.Models.Booking r);
    }
}
