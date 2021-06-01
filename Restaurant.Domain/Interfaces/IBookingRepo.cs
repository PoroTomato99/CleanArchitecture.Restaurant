using Restaurant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Interfaces
{
    public interface IBookingRepo
    {
        IEnumerable<Booking> GetBookings();
        Booking GetBooking(int id);
        Booking CreateBooking(Booking x);
        Booking UpdateBooing(Booking x);
        Boolean DeleteBooking(Booking x);

        //Check if existed
        Boolean IsBookingExist(Booking x);
    }
}
