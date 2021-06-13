using Restaurant.Domain.Models;
using Restaurant.Domain.ResponsesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.ViewModel
{
    public class AdminViewModel
    {
        public List<UserProfile> Profiles { get; set; }
        public List<ApplicationUser> Users { get; set; }
        public UserProfile Profile { get; set; }
        public Response ApiResponse { get; set; }
    }
}
