using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Restaurant.Domain.Models
{
    [Table("Restaurant_Follower")]
    public partial class RestaurantFollower
    {
        [Key]
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        [Required]
        [StringLength(450)]
        public string UserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateFollowed { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        [InverseProperty("RestaurantFollowers")]
        public virtual Restaurant Restaurant { get; set; }
    }
}
