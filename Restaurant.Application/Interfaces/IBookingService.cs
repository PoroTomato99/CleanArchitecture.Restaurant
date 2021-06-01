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
        BookingViewModel GetRestaurants();
        BookingViewModel GetRestaurant(int id);
        BookingViewModel CreateRestaurant(Domain.Models.Restaurant r);
        BookingViewModel UpdateRestaurant(Domain.Models.Restaurant r);
        Boolean DeleteRestaurant(Domain.Models.Restaurant r);
    }
}
