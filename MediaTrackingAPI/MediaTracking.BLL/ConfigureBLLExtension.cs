using AutoMapper;
using MediaTracking.BLL.Factories;
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
            services.ConfigureAutoMapper();
            services.ConfigureServices();
            
            services.AddScoped<IServiceFactory, ServiceFactory>();
            services.AddScoped<IJwtFactory, JwtFactory>();

            services.ConfigureDAL(configuration);

        }

        private static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }

        private static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddSingleton(new MapperConfiguration(c =>
            {
            }).CreateMapper());
        }
    }
}