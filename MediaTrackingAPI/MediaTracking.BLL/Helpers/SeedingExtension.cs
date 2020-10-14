using MediaTracking.DAL.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaTracking.BLL.Helpers
{
    public static class SeedingExtension
    {
        public static void Seed(
            this IApplicationBuilder app,
            IServiceProvider services,
            IConfiguration configuration)
        {
            app.SeedEssentialAsync(services, configuration).Wait();
        }
    }
}
