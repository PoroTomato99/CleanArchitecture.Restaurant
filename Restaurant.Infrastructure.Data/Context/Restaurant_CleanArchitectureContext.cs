using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Restaurant.Domain.Models;

#nullable disable

namespace Restaurant.Infrastructure.Data.Context
{
    public partial class Restaurant_CleanArchitectureContext : DbContext
    {
        public Restaurant_CleanArchitectureContext(DbContextOptions<Restaurant_CleanArchitectureContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<OwnerRegisterForm> OwnerRegisterForms { get; set; }
        public virtual DbSet<Domain.Models.Restaurant> Restaurants { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }

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

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.ReservationTime).IsUnicode(false);

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.RestaurantId)
                    .HasConstraintName("FK_Booking_Restaurant");
            });

            modelBuilder.Entity<Domain.Models.Restaurant>(entity =>
            {
                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Restaurants)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_Restaurant_Address");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
