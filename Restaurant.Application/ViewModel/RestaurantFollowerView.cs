using Restaurant.Domain.Models;
using Restaurant.Domain.ResponsesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.ViewModel
{
    public class RestaurantFollowerView
    {
        public Domain.Models.Restaurant Restaurant { get; set; }
        public List<RestaurantFollower> FollowerDetail { get; set; }
        public int TotalFollower { get; set; }
        public Response Response { get; set; }
    }
}
