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
    public class UserProfileRepo : IUserProfileRepo
    {
        private readonly Restaurant_CleanArchitectureContext _context;
        public UserProfileRepo(Restaurant_CleanArchitectureContext context)
        {
            _context = context;
        }

        public UserProfile CreateUserProfile(UserProfile profile)
        {
            var transaction = _context.Database.BeginTransaction();
            //check if profile existed
            var exist = GetUserProfile(profile.Username);
            if(exist != null)
            {
                throw new DuplicateNameException($"{profile.Username}'s Profile Already Existed");
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
