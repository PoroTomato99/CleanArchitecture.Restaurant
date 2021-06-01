using Restaurant.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Interfaces
{
    public interface IRestaurantService
    {
        RestaurantViewModel GetRestaurants();
        RestaurantViewModel GetRestaurant(int id);
        RestaurantViewModel CreateRestaurant(Domain.Models.Restaurant r);
        RestaurantViewModel UpdateRestaurant(Domain.Models.Restaurant r);
        Boolean DeleteRestaurant(Domain.Models.Restaurant r);
    }
}
