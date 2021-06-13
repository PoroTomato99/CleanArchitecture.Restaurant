using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.AuthenticationModel;

#nullable disable

namespace Restaurant.Domain.Models
{
    [Table("Announcement")]
    public partial class Announcement
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Type { get; set; }
        [Required]
        [StringLength(100)]
        public string Message { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateCreated { get; set; }
        [Required]
        [StringLength(450)]
        public string CreatedBy { get; set; }
        [Required]
        [StringLength(100)]
        public string TargetTo { get; set; }
        [StringLength(450)]
        public string UserId { get; set; }

        public override string ToString()
        {
            List<string> RoleItems = UserRoles.RoleItems();

            if (RoleItems.Contains(TargetTo))
            {
                return $"Announcement Id : {Id}\n" +
                        $"Announcement Type : {Type}\n" +
                        $"Date Created : {DateCreated}\n" +
                        $"Created By : {CreatedBy}\n" +
                        $"Target To : {TargetTo }\n" +
                        $"UserId : All";
            }
            else
            {
                return $"Announcement Id : {Id}\n" +
                    $"Announcement Type : {Type}\n" +
                    $"Date Created : {DateCreated}\n" +
                    $"Created By : {CreatedBy}\n" +
                    $"Target To : {TargetTo }\n" +
                    $"UserId : {UserId}";
            }
        }
    }
}
