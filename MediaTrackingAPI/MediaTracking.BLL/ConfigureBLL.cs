using MediaTracking.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediaTracking.BLL
{
    public class ConfigureBLL
    {
        public static void Configure(IConfiguration configuration,IServiceCollection services)
        {
            ConfigureDAL.Configure(configuration, services);
        }
    }
}