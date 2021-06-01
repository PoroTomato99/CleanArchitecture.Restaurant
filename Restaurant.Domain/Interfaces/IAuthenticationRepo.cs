using Restaurant.Domain.AuthenticationModel;
using Restaurant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Interfaces
{
    public interface IAuthenticationRepo
    {
        Task<ApplicationUser> RegisterAdminAsync(Register_Admin x);
    }
}
