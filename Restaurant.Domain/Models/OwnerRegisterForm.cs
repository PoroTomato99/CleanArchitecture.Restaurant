using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Restaurant.Domain.Models
{
    [Keyless]
    [Table("Owner_Register_Form")]
    public partial class OwnerRegisterForm
    {
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ApplicationDate { get; set; }
        [Required]
        [Column("Restaurant_Name")]
        [StringLength(100)]
        public string RestaurantName { get; set; }
        [Required]
        [StringLength(150)]
        public string Description { get; set; }
        [Required]
        [StringLength(450)]
        public string UserId { get; set; }
        public int? ApplicationStatus { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ApprovedDate { get; set; }
        [StringLength(450)]
        public string ApprovedBy { get; set; }
    }
}
