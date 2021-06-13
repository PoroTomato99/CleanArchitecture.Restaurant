using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Models;
using Restaurant.Domain.Models.Status;
using Restaurant.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Data.Repositories
{
    public class BookingRepo : IBookingRepo
    {

        private readonly Restaurant_CleanArchitectureContext _context;
        public BookingRepo(Restaurant_CleanArchitectureContext context)
        {
            _context = context;
        }

        public Booking CreateBooking(Booking x)
        {
            //if value null
            if (x == null)
            {
                throw new Exception("No Value Found !");
            }
            /*find if any booking with this condition 
                1- same booking time 
                2- same user id 
                3 -same booking date
                4 -booking status !(completed/cancelled/rejected)

                5- get open and end time
                6- get current time and date
             */
            var getRestaurant = _context.Restaurants.Find(x.RestaurantId);

            /*open and end time*/
            var openHour = TimeSpan.Parse(_context.Restaurants.Find(x.RestaurantId).OpenHour);
            var endHour = TimeSpan.Parse(_context.Restaurants.Find(x.RestaurantId).EndHour);

            /*reservation date time*/
            var reservedTime = TimeSpan.Parse(x.ReservationTime);
            var reservedDate = x.ReservationDate;


            if (reservedTime < openHour && reservedTime > endHour)
            {
                Console.WriteLine($"reserved time < open : {reservedTime < openHour}");
                Console.WriteLine($"reserved time > endhour : {reservedTime > endHour}");
                Console.WriteLine($"reserved time < open && reserved time > endhour : {reservedTime < openHour && reservedTime > endHour}");
                throw new Exception("Invalid Reversation Time !");
            }

            /*Get exisiting reservation date*/
            var getReservations = _context.Bookings.Where(b => b.RestaurantId == getRestaurant.Id &&
                                                          b.ReservationDate == x.ReservationDate &&
                                                          b.ReservationTime == x.ReservationTime &&
                                                          b.Status != BookingStatus.Completed &&
                                                          b.Status != BookingStatus.Rejected &&
                                                          b.Status != BookingStatus.Cancelled).ToList();

            /*check if the exisitng reservation >= table quaitity*/
            if (getReservations.Count >= getRestaurant.TableQty)
            {
                if (getReservations.Any(b => b.ReservedBy == x.ReservedBy))
                {
                    var i = getReservations.Where(b => b.ReservedBy == x.ReservedBy).First();
                    Console.WriteLine(i.ToString());
                    throw new Exception("Booking Existed and is Not Yet Attended");
                }
                var count = getReservations.Count();
                Console.WriteLine($"Total of booking found for time : {x.ReservationTime} is {count}");
                throw new Exception("The time is Fully Booked !");
            }

            var transaction = _context.Database.BeginTransaction();
            x.Status = BookingStatus.Pending;
            x.LastUpdate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            _context.Bookings.Add(x);
            try
            {
                _context.SaveChanges();
                transaction.Commit();
                return _context.Bookings.Find(x.Id);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message);
            }
        }


        public bool DeleteBooking(Booking x)
        {
            throw new NotImplementedException();
        }

        public Booking GetBooking(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Booking> GetBookings()
        {
            return _context.Bookings;
        }

        public bool IsBookingExist(Booking x)
        {
            throw new NotImplementedException();
        }

        public Booking UpdateBooing(Booking x)
        {
            throw new NotImplementedException();
        }
    }
}
