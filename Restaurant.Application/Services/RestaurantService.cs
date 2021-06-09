using Microsoft.AspNetCore.Http;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModel;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.ResponsesModels;
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
                Restaurant = _restaurant.GetRestaurant(id),
                Response = new Response(StatusCodes.Status200OK.ToString(), "Successfully Get Restaurants")
            };
        }

        public RestaurantViewModel GetRestaurants()
        {

            return new RestaurantViewModel()
            {
                Restaurants = _restaurant.GetRestaurants(),
                Response = new Response($"{StatusCodes.Status200OK}", $"Successfully Retrieve List of Restaurants")
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
