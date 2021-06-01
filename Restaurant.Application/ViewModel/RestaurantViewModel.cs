using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Restaurant.Application.ViewModel
{
    public class RestaurantViewModel
    {
        public IEnumerable<Domain.Models.Restaurant> Restaurants { get; set; }
        public Domain.Models.Restaurant Restaurant { get; set; }
        public Domain.ResponsesModels.Response Response { get; set; }
    }
}
