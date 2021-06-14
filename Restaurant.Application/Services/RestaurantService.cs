using Microsoft.AspNetCore.Http;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModel;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Models;
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



        public RestaurantFollowerView GetFollowers(int id)
        {
            var getFollower = _restaurant.GetRestaurantFollower(id);

            return new()
            {
                FollowerDetail = getFollower,
                TotalFollower = getFollower.Count()
            };
        }

        public RestaurantFollowerView GetSInglerFollower(int id)
        {
            var SingleDetail = _restaurant.GetSInglerFollower(id);

            var newItems = new List<RestaurantFollower>();
            newItems.Add(SingleDetail);
            return new()
            {
                FollowerDetail = newItems
            };
        }
        public RestaurantFollowerView FollowRestaurant(RestaurantFollower follow)
        {
            var addFollower = _restaurant.FollowRestaurant(follow);

            var restaurant = _restaurant.GetRestaurant(follow.RestaurantId);

            List<RestaurantFollower> follower = new();
            follower.Add(addFollower);
            return new()
            {
                FollowerDetail = follower,
                Response = new("Successful", $"Following {restaurant.RestaurantName}")
            };
        }


        public bool Unfollow(RestaurantFollower unfollow)
        {
            var x = _restaurant.Unfollow(unfollow);
            return x;
        }
    }
}
