using Restaurant.Application.ViewModel;
using Restaurant.Domain.AuthenticationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Interfaces
{
    public interface IAuthenticationService
    {
        AuthenticationViewModel CreateAdmin(Register_Admin x);
        AuthenticationViewModel DeleteAdmin(string userId);
        AuthenticationViewModel LoginUser(Login_Model credentials);
    }
}
