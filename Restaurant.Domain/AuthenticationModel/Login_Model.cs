using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.AuthenticationModel
{
    public class Login_Model
    {
        [Required(ErrorMessage = "Username Required!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password Required!")]
        public string Password { get; set; }
    }
}
