using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Models
{
    public class Type_Restaurant
    {
        public const string FastFood = "Fast Food";
        public const string Beverage = "Beverage";
        public const string Cafe = "Cafe";
        public const string Bar = "Bar";
        public const string Restaurant = "Dine In Restaurant";
        public const string FineDining = "Fine Dining Restaurant";
        public const string Buffet = "Buffet";
        public const string Steamboat = "Steam Boat";
        public const string JapaneseCuisine = "Japanese Cuisine";
        public const string KoreanBBQ = "Korean Barbecue";
        public const string KoreanBar = "Korean Cafe Bar";

        public static List<string> RestaurantTypes()
        {
            return new List<string>()
            {
                FastFood,
                Beverage,
                Cafe ,
                Bar ,
                Restaurant,
                FineDining ,
                Buffet,
                Steamboat,
                JapaneseCuisine,
                KoreanBBQ,
                KoreanBar
            };
        }
    }
}
