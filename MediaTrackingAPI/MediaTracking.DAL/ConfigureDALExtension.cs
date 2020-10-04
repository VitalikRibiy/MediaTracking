using System.Text;
using MediaTracking.DAL.Context;
using MediaTracking.DAL.Models.Authentication;
using MediaTracking.DAL.Repositories.Implementations;
using MediaTracking.DAL.Repositories.IRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace MediaTracking.DAL
{
    public static class ConfigureDALExtension
    {
        public static void ConfigureDAL(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<MediaTrackingDbContext>(opt => opt.UseSqlServer
            (configuration.GetConnectionString("DefaultConnection")));
            services.ConfigureIdentity();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = configuration["JWT:ValidIssuer"],
 
                            ValidateAudience = true,
                            ValidAudience = configuration["JWT:ValidAudience"],
                            ValidateLifetime = true,
 
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
                            ValidateIssuerSigningKey = true,
                        };
                    });
        }

        private static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<UserManager<ApplicationUser>>();
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