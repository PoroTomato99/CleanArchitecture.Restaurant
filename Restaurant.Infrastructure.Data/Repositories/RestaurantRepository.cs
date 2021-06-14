using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Models;
using Restaurant.Domain.ResponsesModels;
using Restaurant.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    }
}
