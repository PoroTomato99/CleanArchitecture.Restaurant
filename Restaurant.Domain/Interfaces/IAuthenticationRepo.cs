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
        Task<bool> DeleteAdminAsync(string userId);
        Task<JwtToken> LoginAdmin(Login_Model credentials);
        Task<UserProfile> GetUserProfile(string username);


        Task<ApplicationUser> RegisterUserAsync(Register_Admin user);
        //Task<bool> DeleteUserAsync(string userId);
        public Task<UserProfile> UpdateRole(UserProfile user);

        public List<ApplicationUser> GetApplicationUsers();
    }
}
