using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Restaurant.Domain.Models
{
    [Table("Address")]
    public partial class Address
    {
        public Address()
        {
            Restaurants = new HashSet<Restaurant>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column("Building_No")]
        [StringLength(20)]
        public string BuildingNo { get; set; }
        [Required]
        [StringLength(150)]
        public string Address1 { get; set; }
        [StringLength(150)]
        public string Address2 { get; set; }
        [Required]
        [StringLength(100)]
        public string City { get; set; }
        [Required]
        [StringLength(50)]
        public string State { get; set; }
        [Required]
        [StringLength(50)]
        public string PostCode { get; set; }
        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [InverseProperty(nameof(Restaurant.Address))]
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
