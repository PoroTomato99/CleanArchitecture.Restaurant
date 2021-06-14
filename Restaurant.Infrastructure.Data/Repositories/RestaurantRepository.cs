using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Models;
using Restaurant.Domain.ResponsesModels;
using Restaurant.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Data.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly Restaurant_CleanArchitectureContext _context;
        public RestaurantRepository(Restaurant_CleanArchitectureContext context)
        {
            _context = context;
        }

        public Domain.Models.Restaurant AddRestaurant(Domain.Models.Restaurant x)
        {
            //check if restaurant existed
            var exist = IsRestaurantExist(x);
            if (exist)
            {
                throw new DuplicateNameException("Restaurant Name Already Existed");
            }

            _context.Restaurants.Add(x);
            try
            {
                _context.SaveChanges();
                return _context.Restaurants.Find(x.Id);
            }
            catch (Exception e)
            {
                throw new SaveDbException(e.GetType().ToString(), e.Message);
            }
        }
        public Domain.Models.Restaurant GetRestaurant(int id)
        {
            return _context.Restaurants.Find(id);
        }
        public IEnumerable<Domain.Models.Restaurant> GetRestaurants()
        {
            return _context.Restaurants;
        }
        public bool DeleteRestaurant(Domain.Models.Restaurant x)
        {
            _context.Restaurants.Remove(x);
            try
            {
                _context.SaveChanges();
                var r = _context.Restaurants.Find(x.Id);
                if (r == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception) 
            {       
                throw;
            }
        }
        public bool IsRestaurantExist(Domain.Models.Restaurant x)
        {
            var exist = _context.Restaurants.Any(r => r.RestaurantName == x.RestaurantName);
            if (exist)
            {
                return true;
            }
            return false;
        }
        public Domain.Models.Restaurant UpdateRestaurant(Domain.Models.Restaurant x)
        {
            var x_restaurant = _context.Restaurants.Find(x.Id);
            if(x_restaurant == null)
            {
                throw new Exception($"Restaurant Not Found!");
            }

            x_restaurant.RestaurantName = x.RestaurantName;
            x_restaurant.Type = x.Type;
            x_restaurant.OpenHour = x.OpenHour;
            x_restaurant.EndHour = x.EndHour;
            x_restaurant.Description = x.Description;
            x_restaurant.UserId = x.UserId;
            x_restaurant.Status = x.Status;
            x_restaurant.ApprovedBy = x.ApprovedBy;
            x_restaurant.AppovalDate = x.AppovalDate;

            _context.Restaurants.Update(x_restaurant);
            try
            {
                _context.SaveChanges();
                return _context.Restaurants.Find(x.Id);
            }
            catch (Exception e)
            {
                throw new SaveDbException(e.GetType().ToString(), e.Message);
            }
        }


        /*Get Restaurant with follower*/
        public List<RestaurantFollower> GetRestaurantFollower(int id)
        {
            //check if there is follower
            var follower = _context.RestaurantFollowers.Where(x => x.RestaurantId == id).ToList();
            return follower;
        }

        public RestaurantFollower GetSInglerFollower(int id)
        {
            var detail = _context.RestaurantFollowers.Find(id);
            return detail;
        }

        public RestaurantFollower FollowRestaurant(RestaurantFollower follow)
        {
            if(follow == null)
            {
                throw new Exception("Bad Request");
            }

            var transaction = _context.Database.BeginTransaction();



            _context.RestaurantFollowers.Add(follow);
            try
            {
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }

            var following = _context.RestaurantFollowers.Where(x => x.UserId == follow.UserId && x.RestaurantId == follow.RestaurantId).FirstOrDefault();
            if(following != null)
            {
                return following;
            }
            else
            {
                return null;
            }
        }


        public bool Unfollow(RestaurantFollower follower)
        {
            var x = _context.RestaurantFollowers.Where(y => y.UserId == follower.UserId && y.RestaurantId == y.RestaurantId).FirstOrDefault();
            if(x != null)
            {
                var transaction = _context.Database.BeginTransaction();
                _context.RestaurantFollowers.Remove(x);
                try
                {
                    _context.SaveChanges();
                    var check = _context.RestaurantFollowers.Find(x.Id);
                    if(check != null)
                    {
                        transaction.Rollback();
                        return false;
                    }
                    else
                    {
                        transaction.Commit();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Log Error : {ex.Message}");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
