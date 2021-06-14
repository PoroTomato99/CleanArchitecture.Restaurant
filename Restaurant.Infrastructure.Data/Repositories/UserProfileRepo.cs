using Microsoft.AspNetCore.Identity;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Models;
using Restaurant.Domain.Models.Status;
using Restaurant.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Data.Repositories
{
    public class UserProfileRepo : IUserProfileRepo
    {
        private readonly Restaurant_CleanArchitectureContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public UserProfileRepo(Restaurant_CleanArchitectureContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public UserProfile CreateUserProfile(UserProfile profile)
        {
            var transaction = _context.Database.BeginTransaction();
            //check if profile existed
            var exist = GetUserProfile(profile.Username);

            var checkRequest = _context.UserProfiles.Where(x => x.Username == profile.Username && x.Role == profile.Role).FirstOrDefault();
            if(exist != null)
            {
                throw new DuplicateNameException($"{profile.Username}'s Profile Already Requested for {profile.Role}");
            }
            
            _context.UserProfiles.Add(profile);
            _context.SaveChanges();
            try
            {
                transaction.Commit();
                return _context.UserProfiles.Where(x => x.Username == profile.Username).FirstOrDefault();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine($"{ex.GetType()}: {ex.Message}");
                throw new Exception($"{ex.GetType()}:{ex.Message}");
            }
            
        }

        public bool DeleteProfile(UserProfile profile)
        {
            throw new NotImplementedException();
        }

        public UserProfile GetUserProfile(string username)
        {          
            try
            {
                var profile = _context.UserProfiles.Where(x => x.Username == username).FirstOrDefault();
                if(profile == null)
                {
                    return null;
                }
                else
                {
                    var user = userManager.FindByNameAsync(username);
                    var userRoles = userManager.GetRolesAsync(user.Result);
                    profile.Roles = (List<string>) userRoles.Result;
                    return profile;
                }

            }
            catch (Exception ex)
            {

                throw new Exception($"Some is Wrong with Database! : {ex.Message}");
            }
        }

        public List<UserProfile> GetUserProfiles()
        {
            try
            {
                var profiles = _context.UserProfiles.ToList();
                if(profiles == null)
                {
                    throw new Exception("No Profiles In Database Yet!");
                }
                else
                {
                    return profiles;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType()} : {ex.Message}");
                throw new Exception($"Database Error! : {ex.Message}");
            }
        }

        public bool IsProfileExist(string username)
        {
            throw new NotImplementedException();
        }

        public UserProfile UpdateProfile(UserProfile profile)
        {
            throw new NotImplementedException();
        }
    }
}
