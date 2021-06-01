using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.AuthenticationModel;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Models;
using Restaurant.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Data.Repositories
{
    public class AuthenticationRepo : IAuthenticationRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        //private readonly IEmailSender _emailSender;
        private readonly ILogger<AuthenticationRepo> _logger;

        //contructor
        public AuthenticationRepo(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, ILogger<AuthenticationRepo> logger)
        {
            _context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
            _logger = logger;
        }

        public async Task<ApplicationUser> RegisterAdminAsync(Register_Admin x)
        {
            //check if user existed
            var user = await userManager.FindByNameAsync(x.Username);
            if(user != null)
            {
                throw new DuplicateNameException("Username Taken!");
            }
            var email = await userManager.FindByEmailAsync(x.Email);
            if (email != null)
            {
                throw new DuplicateNameException("Email Already Registered!");
            }

            ApplicationUser admin = new()
            {
                Email = x.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = x.Username
            };

            try
            {
                var createUser = await userManager.CreateAsync(admin, x.Password);
                if (!createUser.Succeeded)
                {
                    throw new SaveDbException(createUser.Errors.ToList()[0].Code,createUser.Errors.ToList()[1].Description);
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
                    await userManager.AddToRoleAsync(user, UserRoles.Admin);
                }

                return await userManager.FindByNameAsync(x.Username);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType()} : {ex.Message}");
                throw;
            }
        }
    }
}
