using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web;
using Restaurant.Domain.AuthenticationModel;
using Restaurant.Domain.Models;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModel;

namespace Restaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authentication;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authentication = authenticationService;
        }

        //register admin
        [HttpPost("admin-registration")]
        public IActionResult RegisterAdmin([FromBody] Register_Admin admin)
        {
            try
            {
                /*call IAuthenticationService*/
                var CreateAdmin = _authentication.CreateAdmin(admin);
                return Ok(CreateAdmin);
            }
            catch (Exception ex)
            {
                var response = new Domain.ResponsesModels.Response(type: ex.GetType().ToString(), message: ex.Message);
                return Conflict(new AuthenticationViewModel()
                {
                    Response = response
                });
            }
        }

        [HttpDelete("delete-admin/{userId}")]
        public IActionResult DeleteAdmin([FromRoute]string userId)
        {
            try
            {
                var DeleteAdmin = _authentication.DeleteAdmin(userId);
                return Ok(DeleteAdmin);
            }
            catch (Exception ex)
            {
                return Conflict(new AuthenticationViewModel()
                {
                    Response = new(ex.GetType().ToString(), ex.Message)
                });
            }
        }

        [HttpPut("owner-registration/{userId}")]
        public IActionResult CreateOwner([FromRoute] string userId)
        {
            return Ok("This is to Create Restaurant Owner");
        }

        [HttpPost("login")]
        public IActionResult LoginUser([FromBody] Login_Model credentials)
        {
            try
            {
                var LoginUser = _authentication.LoginUser(credentials);

                return Ok(LoginUser);
            }
            catch (Exception ex)
            {
                return Conflict(new AuthenticationViewModel()
                {
                    Response = new(ex.GetType().ToString(), ex.Message)
                });
            }
        }

    }
}
