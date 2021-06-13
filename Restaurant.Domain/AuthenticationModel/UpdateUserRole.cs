using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.AuthenticationModel
{
    public class UpdateUserRole
    {
        public string UserId { get; set; }
        public string Role { get; set; }
    }
}
