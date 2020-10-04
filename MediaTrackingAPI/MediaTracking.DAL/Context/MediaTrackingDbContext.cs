using MediaTracking.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MediaTracking.DAL.Models.Authentication;

namespace MediaTracking.DAL.Context
{
    public class MediaTrackingDbContext : IdentityDbContext<ApplicationUser, Role, string, IdentityUserClaim<string>,
        UserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        private string _currentUserId;
        public MediaTrackingDbContext(DbContextOptions<MediaTrackingDbContext> opt) : base(opt)
        {

        }

        public string CurrentUserId
        {
            get => _currentUserId;
            set
            {
                if (_currentUserId != value)
                {
                    _currentUserId = value;
                }
            }
        }
    }
}