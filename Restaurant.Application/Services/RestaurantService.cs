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
            var CreateRestaurant = _restaurant.AddRestaurant(r);
            return new RestaurantViewModel()
            {
                Restaurant = CreateRestaurant
            };
        }

        public bool DeleteRestaurant(Domain.Models.Restaurant r)
        {
            var deleteRestaurant = _restaurant.DeleteRestaurant(r);
            return deleteRestaurant;
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
            var UpdateRestaurant = _restaurant.UpdateRestaurant(r);
            return new RestaurantViewModel()
            {
                Restaurant = UpdateRestaurant
            };
        }
    }
}
