using MediaTracking.DAL.Context;
using MediaTracking.DAL.Models.Authentication;
using MediaTracking.DAL.Repositories.Implementations;
using MediaTracking.DAL.Repositories.IRepositories;
using MediaTracking.DAL.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediaTracking.DAL
{
    public static class ConfigureDALExtension
    {
        public static void ConfigureDAL(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<MediaTrackingDbContext>(opt => opt.UseSqlServer
                (configuration.GetConnectionString("DefaultConnection")));
            services.ConfigureRepositories();
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.ConfigureIdentity();
        }

        private static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<UserManager<ApplicationUser>>();
            services.AddScoped<RoleManager<Role>>();
            services.AddScoped<IUserRepository,UserRepository>();
        }

        private static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, Role>(options => options.Stores.MaxLengthForKeys = 128)
                .AddEntityFrameworkStores<MediaTrackingDbContext>()
                .AddRoleManager<RoleManager<Role>>()
                .AddUserManager<UserManager<ApplicationUser>>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });
        }
    }
}