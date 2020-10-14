using System.Collections.Generic;
using MediaTracking.DAL.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace MediaTracking.DAL.Models.Authentication
{
    public class ApplicationUser : IdentityUser<string>
    {
        public ICollection<UserRole> UserRoles { get; set; }
        public bool IsActive {get;set;}
        public string FullName { get; set; }
        public string Country { get; set; }
        public ICollection<Media> WatchList { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}