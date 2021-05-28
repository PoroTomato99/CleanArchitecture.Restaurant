using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Models
{
    [Table("Restaurant")]
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string RestaurantName { get; set; }
        public int Type { get; set; }
        //[Column(TypeName = "time(2)")]
        public string OpenHour { get; set; }
        //[Column(TypeName = "time(2)")]
        public string EndHour { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
    }
}
