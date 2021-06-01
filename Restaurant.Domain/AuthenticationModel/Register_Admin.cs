using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.AuthenticationModel
{
    public class Register_Admin
    {
        [Required(ErrorMessage = "User Name Required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email Address Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }
    }
}
