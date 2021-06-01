using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Interfaces;
using Restaurant.Application.Services;
using Restaurant.Domain.Interfaces;
using Restaurant.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Restaurant.Application
            services.AddScoped<IRestaurantService, RestaurantService>();

            //Restaurant.Domain.Interface || Restaurant.Infrastructure.Data.Repositories
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();

            ////Authentication Application 
            //services.AddScoped<IAuthenticationService, AuthenticationService>();
            //services.AddScoped<IAuthenticationRepo, AuthenticationRepo>();

            //Booking Application 
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IBookingRepo, BookingRepo>();
            
        }
    }
}
