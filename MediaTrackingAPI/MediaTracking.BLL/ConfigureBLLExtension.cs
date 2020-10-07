using AutoMapper;
using MediaTracking.BLL.Factories;
using MediaTracking.BLL.Mappings;
using MediaTracking.BLL.Services;
using MediaTracking.BLL.Services.IServices;
using MediaTracking.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediaTracking.BLL
{
    public static class ConfigureBLLExtension
    {
        public static void ConfigureBLL(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDAL(configuration);
            services.ConfigureAutoMapper();
            services.ConfigureServices();
            
            services.AddScoped<IServiceFactory, ServiceFactory>();
            services.AddScoped<IJwtFactory, JwtFactory>();
        }

        private static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
        }

        private static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.AddProfile(new UserProfile());
                config.AddProfile(new RoleProfile());
            }).CreateMapper());
        }
    }
}