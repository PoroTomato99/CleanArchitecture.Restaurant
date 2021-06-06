using Microsoft.AspNetCore.Http;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModel;
using Restaurant.Domain.AuthenticationModel;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.ResponsesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepo _authRepo;

        public AuthenticationService(IAuthenticationRepo authentication)
        {
            _authRepo = authentication;
        }

        public AuthenticationViewModel CreateAdmin(Register_Admin x)
        {
            var CreateAdmin = _authRepo.RegisterAdminAsync(x);
            return new AuthenticationViewModel()
            {
                User = CreateAdmin.Result
            };
        }

        public AuthenticationViewModel DeleteAdmin(string userId)
        {
            var DeleteAdmin = _authRepo.DeleteAdminAsync(userId);
            return new AuthenticationViewModel()
            {
                Response = new Response("Delete User", DeleteAdmin.Result.ToString())
            };
        }

        public AuthenticationViewModel LoginUser(Login_Model credentials)
        {
            return new AuthenticationViewModel()
            {
                Profile = _authRepo.GetUserProfile(credentials.Username).Result,
                Token = _authRepo.LoginAdmin(credentials).Result.Token
            };
        }
    }
}
