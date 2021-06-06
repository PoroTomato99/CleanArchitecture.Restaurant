using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Restaurant.Domain.Models
{
    [Table("Restaurant")]
    public partial class Restaurant
    {
        public Restaurant()
        {
            Bookings = new HashSet<Booking>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string RestaurantName { get; set; }
        public int Type { get; set; }
        [Required]
        [StringLength(50)]
        public string OpenHour { get; set; }
        [Required]
        [StringLength(50)]
        public string EndHour { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(450)]
        public string UserId { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AppovalDate { get; set; }
        [StringLength(450)]
        public string ApprovedBy { get; set; }
        public int? AddressId { get; set; }
        public int? TableQty { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Restaurants")]
        public virtual Address Address { get; set; }
        [InverseProperty(nameof(Booking.Restaurant))]
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
