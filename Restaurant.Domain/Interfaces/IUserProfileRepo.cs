using Restaurant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Interfaces
{
    public interface IUserProfileRepo
    {
        UserProfile CreateUserProfile(UserProfile profile);
        List<UserProfile> GetUserProfiles();
        UserProfile GetUserProfile(string username);

        UserProfile UpdateProfile(UserProfile profile);

        bool DeleteProfile(UserProfile profile);

        bool IsProfileExist(string username);
    }
}
