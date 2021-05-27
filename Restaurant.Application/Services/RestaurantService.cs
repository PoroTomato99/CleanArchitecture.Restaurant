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
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurant;
        public RestaurantService(IRestaurantRepository restaurant)
        {
            _restaurant = restaurant;
        }

        public RestaurantViewModel CreateRestaurant(Domain.Models.Restaurant r)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRestaurant(Domain.Models.Restaurant r)
        {
            RestaurantViewModel x = new()
            {
                DeleteRestaurant = _restaurant.DeleteRestaurant(r)
            };
            return x.DeleteRestaurant;
        }

        public RestaurantViewModel GetRestaurant(int id)
        {
            return new RestaurantViewModel()
            {
                Restaurant = _restaurant.GetRestaurant(id)
            };
        }

        public RestaurantViewModel GetRestaurants()
        {
            return new RestaurantViewModel()
            {
                Restaurants = _restaurant.GetRestaurants()
            };
        }

        public RestaurantViewModel UpdateRestaurant(Domain.Models.Restaurant r)
        {
            throw new NotImplementedException();
        }
    }
}
