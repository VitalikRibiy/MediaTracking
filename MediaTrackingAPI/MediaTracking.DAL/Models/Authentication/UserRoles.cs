using Microsoft.AspNetCore.Identity;

namespace MediaTracking.DAL.Models.Authentication
{
    public class UserRole : IdentityUserRole<string>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual Role Role { get; set; }
    }
}