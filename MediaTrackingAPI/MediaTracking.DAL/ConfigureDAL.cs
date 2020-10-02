using MediaTracking.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediaTracking.DAL
{
    public class ConfigureDAL
    {
        public static void Configure(IConfiguration configuration,IServiceCollection services)
        {
            services.AddDbContext<MediaTrackingDbContext>(opt => opt.UseSqlServer
            (configuration.GetConnectionString("DefaultConnection")));
        }
    }
}