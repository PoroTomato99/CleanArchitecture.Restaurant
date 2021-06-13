using Microsoft.AspNetCore.Http;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModel;
using Restaurant.Domain.AuthenticationModel;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Models;
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

        public AuthenticationViewModel UpdateRole(UserProfile user)
        {
            var UpdateUserRole = _authRepo.UpdateRole(user).Result;
            return new AuthenticationViewModel()
            {
                Profile = UpdateUserRole
            };
        }

        public AuthenticationViewModel CreateCustomer(Register_Admin customer)
        {
            var CreateCustomer = _authRepo.RegisterUserAsync(customer);
            return new AuthenticationViewModel()
            {
                User = CreateCustomer.Result,
                Profile = _authRepo.GetUserProfile(customer.Username).Result
            };
        }

        public AuthenticationViewModel GetApplicationUsers()
        {
            return new AuthenticationViewModel()
            {
                ApplicationUsers = _authRepo.GetApplicationUsers()
            };
        }
        //public AuthenticationViewModel DeleteUserAsync(string userId)
        //{
        //    return new AuthenticationViewModel()
        //    {
        //        Response = _authRepo.DeleteUserAsync(userId).Result
        //    };
        //}
    }
}
