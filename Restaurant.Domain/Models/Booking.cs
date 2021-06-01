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
        [Column(TypeName = "datetime")]
        public DateTime BookingDate { get; set; }
        [Required]
        [StringLength(100)]
        public string Remark { get; set; }
        [Column(TypeName = "date")]
        public DateTime ReservationDate { get; set; }
        [Required]
        [StringLength(10)]
        public string ReservationTime { get; set; }
        [StringLength(450)]
        public string UserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }
        [StringLength(450)]
        public string UpdatedBy { get; set; }
    }
}
