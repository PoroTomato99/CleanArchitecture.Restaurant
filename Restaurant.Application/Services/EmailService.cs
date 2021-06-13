using EasyNetQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> logger;
        private readonly IConfiguration config;


        public void SendEmail()
        {
            using var bus = RabbitHutch.CreateBus("host=localhost");
            bus.PubSub.Subscribe<Announcement>("",HandleNotification);
            Console.WriteLine("----------Listening for Announcement-------------");
            Console.ReadLine(); 
        }

        public static void HandleNotification(Announcement anct)
        {
            //see the announcement target 

            //print out the result
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(anct.ToString());
            Console.ResetColor();
        }
    }
}
