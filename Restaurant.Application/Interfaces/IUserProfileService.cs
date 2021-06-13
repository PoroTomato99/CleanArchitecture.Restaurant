using Restaurant.Application.ViewModel;
using Restaurant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Interfaces
{
    public interface IUserProfileService
    {
        AdminViewModel GetProfiles();
        AdminViewModel GetProfile(string username);
        AdminViewModel CreateProfile(UserProfile profile);
        AdminViewModel UpdateProfile(UserProfile profile);
        bool DeleteProfile(UserProfile profile);
    }
}
