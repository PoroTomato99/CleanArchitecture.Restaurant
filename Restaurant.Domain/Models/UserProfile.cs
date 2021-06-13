using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Restaurant.Domain.Models
{
    [Table("UserProfile")]
    public partial class UserProfile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(450)]
        public string UserId { get; set; }

        [Required]
        [StringLength(256)]
        public string Username { get; set; }

        [StringLength(256)]
        [Required(ErrorMessage = "First Name Required!")]
        public string FirstName { get; set; }

        [StringLength(256)]
        [Required(ErrorMessage = "Last  Name Required!")]
        public string LastName { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Please Select a Role")]
        public string Role { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DateRequested { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DateUpdated { get; set; }

        [StringLength(450)]
        public string UpdatedBy { get; set; }

        [NotMapped]
        public List<string> Roles { get; set; }
    }
}
















