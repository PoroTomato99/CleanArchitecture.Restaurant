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
    }
}
