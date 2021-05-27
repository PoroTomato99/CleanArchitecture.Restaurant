using System;
using Microsoft.EntityFrameworkCore;



#nullable disable

namespace Restaurant.Infrastructure.Data.Context
{
    public partial class Restaurant_CleanArchitectureContext : DbContext
    {
        public Restaurant_CleanArchitectureContext(DbContextOptions<Restaurant_CleanArchitectureContext> options)
    : base(options)
        {
        }
        public DbSet<Domain.Models.Restaurant> Restaurants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=Restaurant_Conn");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
