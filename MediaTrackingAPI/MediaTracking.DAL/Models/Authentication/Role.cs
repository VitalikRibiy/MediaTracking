using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MediaTracking.DAL.Models.Authentication
{
    public class Role : IdentityRole
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }
        public virtual ApplicationUser Create { get; set; }
        public virtual ApplicationUser Mod { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}