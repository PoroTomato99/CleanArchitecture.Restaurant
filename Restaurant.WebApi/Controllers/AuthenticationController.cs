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
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        //private readonly IEmailSender _emailSender;
        private readonly ILogger<AuthenticationController> _logger;


        //Dependency Injection
        public AuthenticationController(RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager, ILogger<AuthenticationController> logger)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _logger = logger;
        }

        //private readonly IAuthenticationService _authentication;
        //public AuthenticationController(IAuthenticationService authenticationService)
        //{
        //    _authentication = authenticationService;
        //}

        //register admin
        [HttpPost("admin-register-registration")]
        public async Task<IActionResult> RegisterAdmin([FromBody] Register_Admin admin)
        {
            //try
            //{
            //    call IAuthenticationService
            //    var CreateAdmin = _authentication.CreateAdmin(admin);
            //    return Ok(CreateAdmin);
            //}
            //catch (Exception ex)
            //{
            //    var response = new Domain.ResponsesModels.Response(type: ex.GetType().ToString(), message: ex.Message);
            //    return Conflict(new AuthenticationViewModel()
            //    {
            //        Response = response
            //    });
            //}
            //check if user existed
            var user = await userManager.FindByNameAsync(admin.Username);
            if (user != null)
            {
                return Conflict("User Existed");
            }

            ApplicationUser new_admin = new()
            {
                Email = admin.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = admin.Username
            };

            try
            {
                var createUser = await userManager.CreateAsync(new_admin, admin.Password);
                if (!createUser.Succeeded)
                {
                    return Conflict(createUser.Errors);
                }
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.Customer))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Customer));
                if (!await roleManager.RoleExistsAsync(UserRoles.Owner))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Owner));
                if (!await roleManager.RoleExistsAsync(UserRoles.Employee))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Employee));

                if (await roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await userManager.AddToRoleAsync(new_admin, UserRoles.Admin);
                }

                return Ok(await userManager.FindByNameAsync(admin.Username)); 
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }

    }
}
