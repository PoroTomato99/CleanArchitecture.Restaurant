using Restaurant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.ViewModel
{
    public class UserDetailsView
    {
        public Task<ApplicationUser> UserTable { get; set; }
        public UserProfile Profile { get; set; }
        public Domain.ResponsesModels.Response Response { get; set; }
    }
}
