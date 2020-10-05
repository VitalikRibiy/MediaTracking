using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MediaTracking.DAL.Models.Authentication
{
    public class ApplicationUser : IdentityUser<string>
    {
        public ICollection<UserRole> UserRoles { get; set; }
        public bool IsActive {get;set;}
    }
}