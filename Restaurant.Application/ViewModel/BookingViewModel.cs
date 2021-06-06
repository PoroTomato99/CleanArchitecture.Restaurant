using Restaurant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.ViewModel
{
    public class BookingViewModel
    {
        public IEnumerable<Booking> Bookings { get; set; }
        public Booking Booking { get; set; }
        public Domain.ResponsesModels.Response Response {get;set;}
    }
}
