using Restaurant.Application.ViewModel;
using Restaurant.Domain.AuthenticationModel;
using Restaurant.Domain.Models;
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

        AuthenticationViewModel CreateCustomer(Register_Admin customer);
        //AuthenticationViewModel DeleteUserAsync(string userId);
        AuthenticationViewModel UpdateRole(UserProfile user);
        AuthenticationViewModel GetApplicationUsers();

        UserDetailsView GetUserDetail(string username);

    }
}
