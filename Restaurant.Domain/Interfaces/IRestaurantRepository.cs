using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Interfaces
{
    public interface IRestaurantRepository
    {
        /*IEnumerable used when entire table is large, and many data. So 
         won't need to copy whole thing to application memory
        
         thus won't affect the system performence*/

        /*List & Array both create object in memory, thus it help us to get the data right away but affect
            the overall performace of application.
        */
        //List<Models.Restaurant> GetRestaurants();


        //CRUD Function//
        Models.Restaurant AddRestaurant(Models.Restaurant x);
        IEnumerable<Models.Restaurant> GetRestaurants();
        Models.Restaurant GetRestaurant(int id);
        Models.Restaurant UpdateRestaurant(Models.Restaurant x);
        Boolean DeleteRestaurant(Models.Restaurant x);

        //Check if existed
        Boolean IsRestaurantExist(Models.Restaurant x);
    }
}
