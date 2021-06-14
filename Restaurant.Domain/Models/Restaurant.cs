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
            RestaurantFollowers = new HashSet<RestaurantFollower>();
        }

        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage = "Restaurant Name Required")]
        [StringLength(100)]
        public string RestaurantName { get; set; }

        [Required(ErrorMessage = "Restaurant Type Required")]
        [StringLength(100)]
        public string Type { get; set; }
        [Required(ErrorMessage = "Restaurant Open Hour Required")]
        [StringLength(50)]
        public string OpenHour { get; set; }
        [Required(ErrorMessage = "Restaurant End Hour Required")]
        [StringLength(50)]
        public string EndHour { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "Restaurant Description Required")]
        public string Description { get; set; }
        [StringLength(450)]
        public string UserId { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Status Required")]
        public string Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AppovalDate { get; set; }
        [StringLength(450)]
        public string ApprovedBy { get; set; }
        public int? AddressId { get; set; }

        [Required(ErrorMessage = "Table Quantity Required !")]
        public int? TableQty { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Restaurants")]
        public virtual Address Address { get; set; }
        [InverseProperty(nameof(Booking.Restaurant))]
        public virtual ICollection<Booking> Bookings { get; set; }

        [InverseProperty(nameof(RestaurantFollower.Restaurant))]
        public virtual ICollection<RestaurantFollower> RestaurantFollowers { get; set; }
    }
}
