using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Models
{
    public class UserProfile
    {
        public string Username { get; set; }
        public string Fn { get; set; }
        public string Ln { get; set; }
        public List<string> Roles { get; set; }
    }
}
