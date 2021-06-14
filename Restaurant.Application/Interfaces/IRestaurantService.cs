using Restaurant.Application.ViewModel;
using Restaurant.Domain.Models;
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

        RestaurantFollowerView GetSInglerFollower(int id);
        RestaurantFollowerView GetFollowers(int id);

        RestaurantFollowerView FollowRestaurant(RestaurantFollower follow);

        bool Unfollow(RestaurantFollower unfollow);
    }
}
