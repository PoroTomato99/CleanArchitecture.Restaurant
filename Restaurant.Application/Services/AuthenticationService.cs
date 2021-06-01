using Microsoft.AspNetCore.Http;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModel;
using Restaurant.Domain.AuthenticationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationService _authentication;

        public AuthenticationService(IAuthenticationService authentication)
        {
            _authentication = authentication;
        }

        public AuthenticationViewModel CreateAdmin(Register_Admin x)
        {
            var CreateAdmin = _authentication.CreateAdmin(x);
            return new AuthenticationViewModel()
            {
                Response = new Domain.ResponsesModels.Response($"{StatusCodes.Status200OK}", $"Successfuly Created Admin : {x.Username}")
            };
            //if(CreateAdmin != null)
            //{
            //    var Response = new Domain.ResponsesModels.Response(StatusCodes.Status200OK.ToString(), 
            //        $"Sucessfully Created {x.Username}");

            //    CreateAdmin.Response = Response;
            //    return CreateAdmin;
            //}
            //throw new NullReferenceException();
        }
    }
}
