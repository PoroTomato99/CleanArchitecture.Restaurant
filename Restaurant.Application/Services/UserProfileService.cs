using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModel;
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
    public class UserProfileService :IUserProfileService
    {
        private readonly IUserProfileRepo _profileRepo;
        private readonly IAuthenticationRepo _authRepo;

        public UserProfileService(IUserProfileRepo profileRepo, IAuthenticationRepo authRepo)
        {
            _profileRepo = profileRepo;
            _authRepo = authRepo;
        }

        public AdminViewModel CreateProfile(UserProfile profile)
        {
            var response = new Response();
            var create = _profileRepo.CreateUserProfile(profile);
            if (create == null)
            {
                response.Type = $"Unsuccessful";
                response.Message = $"Problem While Creating {profile.Username} Profile";
            }
            else
            {
                response.Type = $"Successful";
                response.Message = $"Created {profile.Username} Profile and Requested Desired Role";
            }
            return new AdminViewModel()
            {
                Profile = create,
                ApiResponse = response
            };
        }

        public bool DeleteProfile(UserProfile profile)
        {
            throw new NotImplementedException();
        }

        public AdminViewModel GetProfile(string username)
        {
            return new AdminViewModel()
            {
                Profile = _profileRepo.GetUserProfile(username)
            };
        }

        public AdminViewModel GetProfiles()
        {
            return new AdminViewModel()
            {
                Profiles = _profileRepo.GetUserProfiles(),
                Users = _authRepo.GetApplicationUsers()
            };
        }

        public AdminViewModel UpdateProfile(UserProfile profile)
        {
            throw new NotImplementedException();
        }
    }
}
