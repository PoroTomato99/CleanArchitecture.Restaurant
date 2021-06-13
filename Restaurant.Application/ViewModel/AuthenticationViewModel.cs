using Restaurant.Domain.AuthenticationModel;
using Restaurant.Domain.Models;
using Restaurant.Domain.ResponsesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.ViewModel
{
    public class AuthenticationViewModel
    { 
        public ApplicationUser User { get; set; }
        public List<ApplicationUser> ApplicationUsers { get; set; }
        public UserProfile Profile { get; set; }
        public string Token { get; set; }
        public Response Response { get; set; }
    }
}
