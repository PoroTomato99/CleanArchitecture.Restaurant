using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Restaurant.Domain.EmailModel;
using Restaurant.Infrastructure.IoC;

namespace Restaurant.Subscriber
{
    class Program
    {
       
        public Program(IConfiguration config)
        {
            _config = config;
        }
        public IConfiguration _config { get; }
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            //logging serilog
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext().WriteTo.Console().CreateLogger();

            Log.Logger.Information("Information Starting");

            var host = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            {
                var config = builder.Build();
                var emailConfig = config.GetSection("EmailConfig").Get<EmailConfiguration>();
                RegisterServices(services);           
            }).UseSerilog().Build();
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            builder.SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("appsetting.json", optional: true, reloadOnChange: true).
                AddJsonFile($"appsetting.{env}.json", optional: true, reloadOnChange: true).
                AddEnvironmentVariables();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);
        }
    }
}
