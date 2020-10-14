using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MediaTracking.DAL.Models.Authentication;
using MediaTracking.DAL.Models.Entities;
using MediaTracking.DAL.Models.Configurations;

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

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Media> Medias { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Studio> Studios { get; set; }

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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ActorConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new DirectorConfiguration());
            builder.ApplyConfiguration(new MediaActorConfiguration());
            builder.ApplyConfiguration(new MediaCategoryConfiguration());
            builder.ApplyConfiguration(new MediaConfiguration());
            builder.ApplyConfiguration(new ReviewConfiguration());
            builder.ApplyConfiguration(new StudioConfiguration());
        }
    }
}