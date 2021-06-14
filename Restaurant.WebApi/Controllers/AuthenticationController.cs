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
        private readonly IUserProfileService _userProfileService;
        public AuthenticationController(IAuthenticationService authenticationService, IUserProfileService userProfileService)
        {
            _authentication = authenticationService;
            _userProfileService = userProfileService;
        }

        /*Login Controller*/
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

        /*register admin*/
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

        [HttpDelete("delete-user/{userId}")]
        public IActionResult DeleteUser([FromRoute] string userId)
        {
            try
            {
                var DeleteUser = _authentication.DeleteAdmin(userId);
                return Ok(DeleteUser);
            }
            catch (Exception ex)
            {
                //log error
                return Conflict(new AuthenticationViewModel()
                {
                    Response = new($"{ex.GetType()}", $"{ex.Message}")
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


        /*Create Customer*/
        [HttpPost("customer")]
        public IActionResult RegisterCustomer([FromBody] Register_Admin customer)
        {
            try
            {
                var CreateCustomer = _authentication.CreateCustomer(customer);
                return Ok(CreateCustomer);
            }
            catch (Exception ex)
            {
                return Conflict(new AuthenticationViewModel()
                {
                    Response = new($"{ex.GetType()}", $"{ex.InnerException.Message}")
                });
            }
        }

        [HttpGet("users")]
        public IActionResult GetApplicationUsers()
        {
            try
            {
                var users = _authentication.GetApplicationUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                var AuthView = new AuthenticationViewModel()
                {
                    Response = new($"{ex.GetType()}", $"{ex.Message}")
                };
                return Conflict(AuthView);

            }
        }

        [HttpGet("customer-role-request-list")]
        public IActionResult RoleRequesList()
        {
            try
            {
                var getList = _userProfileService.GetProfiles();
                return Ok(getList);
            }
            catch (Exception ex)
            {
                return Conflict(new AdminViewModel()
                {
                    ApiResponse = new($"{ex.GetType()}", $"{ex.Message}")
                });
            }
        }

        [HttpGet("user-detail/{username}")]
        public IActionResult GetUserDetail([FromRoute] string username)
        {
            if(username == null)
            {
                return BadRequest(new UserDetailsView()
                {
                    Response = new("Bad Request", "No Username Provided!")
                });
            }
            try
            {
                var getUser = _authentication.GetUserDetail(username);
                return Ok(getUser);
            }
            catch (Exception ex)
            {
                return Conflict(new UserDetailsView()
                {
                    Response = new($"{ex.GetType()}", $"{ex.Message}")
                });
                throw;
            }
        }

        [HttpPost("admin/approve-role")]
        public IActionResult ApproveRole([FromBody] UserProfile profile)
        {
            try
            {
                var approveRole = _authentication.UpdateRole(profile);
                return Ok(approveRole);
            }
            catch (Exception ex)
            {
                var x = new AuthenticationViewModel()
                {
                    Response = new()
                    {
                        Type = $"{ex.GetType()}",
                        Message = $"{ex.Message}"
                    }
                };

                return Conflict(x);
            }
        }


        [HttpPost("customer/request-role")]
        public IActionResult RequestRole([FromBody] UserProfile profile)
        {
            try
            {
                var CreateProfile = _userProfileService.CreateProfile(profile);
                if(CreateProfile.Profile == null)
                {
                    return NotFound(CreateProfile);
                }
                else
                {
                    return Ok(CreateProfile);
                }
            }
            catch (Exception ex)
            {
                var x = new AdminViewModel()
                {
                    ApiResponse = new()
                    {
                        Type = $"{ex.GetType()}",
                        Message = $"{ex.Message}"
                    }
                };
                return Conflict(x);
            }
        }
    }
}
