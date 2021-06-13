using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.AuthenticationModel
{
    public static class UserRoles
    {
        public const string Owner = "Owner";
        public const string Employee = "Employee";
        public const string Customer = "Customer";
        public const string Admin = "Admin";

        public static List<string> RoleItems()
        {
            return new List<string>()
            {
                Owner,
                Employee,
                Customer,
                Admin,
            };
        }
    }
}
