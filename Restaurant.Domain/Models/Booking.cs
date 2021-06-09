using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Restaurant.Domain.Models
{
    [Table("Booking")]
    public partial class Booking
    {
        [Key]
        public int Id { get; set; }
        public int? RestaurantId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime BookingDate { get; set; }

        [StringLength(450)]
        public string ReservedBy { get; set; }

        [Column(TypeName = "date")]
        [Required(ErrorMessage = "Please Choose a Date to Reserve")]
        public DateTime ReservationDate { get; set; }

        [Required(ErrorMessage = "Please Choose A Time to Reserve")]
        [StringLength(10)]
        public string ReservationTime { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }
        [StringLength(450)]
        public string UpdatedBy { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        [InverseProperty("Bookings")]
        public virtual Restaurant Restaurant { get; set; }


        public override string ToString()
        {
            return $"Booking Id : {Id}\n" +
                $"Restaurant Id : {RestaurantId}\n" +
                $"Booking Date : {BookingDate}\n" +
                $"Reserved By : {ReservedBy}\n" +
                $"Reservation Date : {ReservationDate.ToShortDateString()}\n" +
                $"Reservation Time : {ReservationTime}\n" +
                $"Reservation Status : {Status}\n" +
                $"LastUpdated : {LastUpdate}\n" +
                $"UpdatedBy : {UpdatedBy}";
        }
    }
}
