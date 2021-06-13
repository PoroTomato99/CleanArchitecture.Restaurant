using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Domain.AuthenticationModel;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Models;
using Restaurant.Domain.ResponsesModels;
using Restaurant.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Data.Repositories
{
    public class AuthenticationRepo : IAuthenticationRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly Restaurant_CleanArchitectureContext _restContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        //private readonly IEmailSender _emailSender;
        private readonly ILogger<AuthenticationRepo> _logger;
        private readonly IConfiguration _configuration;

        //contructor
        public AuthenticationRepo(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, ILogger<AuthenticationRepo> logger, IConfiguration configuration, Restaurant_CleanArchitectureContext restContext)
        {
            _context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
            _logger = logger;
            _configuration = configuration;
            _restContext = restContext;
        }

        /*To Login user*/
        public async Task<JwtToken> LoginAdmin(Login_Model credentials)
        {
            var user = await userManager.FindByNameAsync(credentials.Username);
            if (await userManager.CheckPasswordAsync(user, credentials.Password) && user != null)
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));


                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return new JwtToken
                {
                    //Username = user.UserName,
                    //Roles = (List<string>)userRoles,
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                };
            }
            throw new Exception("Invalid Username or Password");
        }


        /*To Create Master Admin*/
        public async Task<ApplicationUser> RegisterAdminAsync(Register_Admin x)
        {
            //check if user existed
            var user = await userManager.FindByNameAsync(x.Username);
            if (user != null)
            {
                throw new DuplicateNameException("Username Taken!");
            }
            //check email used
            var email = await userManager.FindByEmailAsync(x.Email);
            if (email != null)
            {
                throw new DuplicateNameException("Email Already Registered!");
            }

            //create Application User object
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
                    throw new SaveDbException(createUser.Errors.ToList()[0].Code, createUser.Errors.ToList()[1].Description);
                }

                //if creation succeeded
                //check if role existed; if not create role;
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.Customer))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Customer));
                if (!await roleManager.RoleExistsAsync(UserRoles.Owner))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Owner));
                if (!await roleManager.RoleExistsAsync(UserRoles.Employee))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Employee));

                //add user to Admin role
                if (await roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await userManager.AddToRoleAsync(admin, UserRoles.Admin);
                }

                return await userManager.FindByNameAsync(x.Username);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType()} : {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DeleteAdminAsync(string userId)
        {
            //check if user exist
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new NullReferenceException($"No User Found !");
            }

            var deleteUser = await userManager.DeleteAsync(user);
            if (!deleteUser.Succeeded)
            {
                throw new SaveDbException("Delete Error", $"Failed to Remove User : {user.UserName}");
            }
            return deleteUser.Succeeded;
        }

        public async Task<UserProfile> GetUserProfile(string username)
        {
            var user = await userManager.FindByNameAsync(username);

            var userRoles = await userManager.GetRolesAsync(user);
            var Profile = new UserProfile()
            {
                UserId = user.Id,
                Username = user.UserName,
                Roles = (List<string>)userRoles
            };
            return Profile;
        }


        /*To Create User*/
        public async Task<ApplicationUser> RegisterUserAsync(Register_Admin user)
        {
            //check if user existed
            var exist_user = await userManager.FindByNameAsync(user.Username);
            if (exist_user != null)
            {
                throw new DuplicateNameException("Username Taken!");
            }

            //check if email exist 
            var exist_email = await userManager.FindByEmailAsync(user.Email);
            if (exist_email != null)
            {
                throw new DuplicateNameException("Email Already Registered!");
            }

            //create Application User object
            ApplicationUser normal_user = new()
            {
                Email = user.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = user.Username
            };

            try
            {
                var createUser = await userManager.CreateAsync(normal_user, user.Password);
                if (!createUser.Succeeded)
                {
                    throw new SaveDbException(createUser.Errors.ToList()[0].Code, createUser.Errors.ToList()[1].Description);
                }

                //if creation succeeded
                //check if role existed; if not create role;
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.Customer))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Customer));
                if (!await roleManager.RoleExistsAsync(UserRoles.Owner))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Owner));
                if (!await roleManager.RoleExistsAsync(UserRoles.Employee))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Employee));

                //add user to normal user to customer role
                if (await roleManager.RoleExistsAsync(UserRoles.Customer))
                {
                    await userManager.AddToRoleAsync(normal_user, UserRoles.Customer);
                }

                return await userManager.FindByNameAsync(user.Username);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType()} : {ex.Message}");
                throw new Exception($"Database Error : {ex.Message}");
            }

        }

        //public async Task<bool> DeleteUserAsync(string userId)
        //{
        //    //check if user exist
        //    var user = await userManager.FindByIdAsync(userId);
        //    if (user == null)
        //    {
        //        throw new NullReferenceException($"No User Found !");
        //    }
        //    var deleteUser = await userManager.DeleteAsync(user);
        //    if (!deleteUser.Succeeded)
        //    {
        //        throw new SaveDbException("Delete Error", $"Failed to Remove User : {user.UserName}");
        //    }
        //    return deleteUser.Succeeded;
        //}


        /*To Promote User Role*/
        public async Task<UserProfile> UpdateRole(UserProfile user)
        {
            //check if usser exist
            var exist_user = await userManager.FindByIdAsync(user.UserId);
            if (exist_user == null)
            {
                throw new Exception("User Not Existed!");
            }
            else
            {
                var UpdateRole = await userManager.AddToRoleAsync(exist_user, user.Role);
                if (!UpdateRole.Succeeded)
                {
                    throw new Exception($"{UpdateRole.Errors.ToList()[1]}");
                }
                else
                {
                    var getUser = await userManager.FindByIdAsync(user.UserId);
                    var roles = await userManager.GetRolesAsync(getUser);

                    var Profile = new UserProfile()
                    {
                        UserId = getUser.Id,
                        Username = getUser.UserName,
                        Roles = (List<string>)roles,
                        UpdatedBy = user.UpdatedBy,
                        DateRequested = user.DateRequested,
                        DateUpdated = user.DateUpdated
                    };
                    return Profile;
                }
            }
        }

        public List<ApplicationUser> GetApplicationUsers()
        {
            var userList = userManager.Users.ToList();
            return userList;
        }
    }
}
