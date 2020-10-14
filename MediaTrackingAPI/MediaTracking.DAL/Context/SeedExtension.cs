using MediaTracking.DAL.Models.Authentication;
using MediaTracking.DAL.Models.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTracking.DAL.Context
{
    public static class SeedExtension
    {
        public static async Task SeedEssentialAsync(
            this IApplicationBuilder app,
            IServiceProvider services,
            IConfiguration configuration)
        {
            services.GetRequiredService<MediaTrackingDbContext>().Database.Migrate();

            await app.SeedRolesAsync(services);
            await app.SeedAdminAsync(services, "Admin","admin" ,"ADMIN","FirstName LastName");
            app.SeedData(services);
        }

        public static async Task SeedRolesAsync(
                            this IApplicationBuilder app,
                            IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<Role>>();
            await CreateIfNotExsits(roleManager, new Role() { Name = "ADMIN"});
            await CreateIfNotExsits(roleManager, new Role() { Name = "USER" });
        }

        public static async Task SeedAdminAsync(
                                 this IApplicationBuilder app,
                                 IServiceProvider services,
                                 string username,
                                 string password,
                                 string role,
                                 string fullName)
        {
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            if (await userManager.FindByNameAsync(username) == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = username,
                    FullName = fullName,
                    Email = "Admin@gmail.com"
                };

                IdentityResult result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }

        public static void SeedData(this IApplicationBuilder app, IServiceProvider services)
        {
            var context = services.GetRequiredService<MediaTrackingDbContext>();

            if (context.Medias.Any()
                || context.Actors.Any()
                || context.Categories.Any()
                || context.Directors.Any()
                || context.Reviews.Any()
                || context.Studios.Any())
            {
                return;
            }

            #region Actors

            var actlist = new List<Actor>();

            var leoDec = new Actor()
            {
                FullName = "Leonardo DiCaprio",
                Biography = "Leonardo DiCaprio's biography",
                Nationality = "American",
                Born = new DateTime(1974, 11, 11)
            };

            actlist.Add(leoDec);

            var tomHard = new Actor()
            {
                FullName = "Tom Hardy",
                Biography = "Tom Hardy's biography",
                Nationality = "United Kingdom",
                Born = new DateTime(1977, 9, 15)
            };

            actlist.Add(tomHard);

            context.Actors.AddRange(actlist);

            #endregion

            #region Directors

            var dirlist = new List<Director>();

            var crisNolan = new Director()
            {
                FullName = "Cristopher Nolan",
                Biography = "Cristopher Nolan biography",
                Nationality = "United Kingdom",
                Born = new DateTime(1970, 7, 30)
            };

            dirlist.Add(crisNolan);

            context.Directors.AddRange(dirlist);

            #endregion

            #region Studios

            var studlist = new List<Studio>();

            var warnerBros = new Studio()
            {
                Name = "Warner Bros. Pictures"
            };

            studlist.Add(warnerBros);

            context.AddRange(studlist);

            #endregion

            #region Categories

            var catlist = new List<Category>();

            var scifi = new Category()
            {
                Name = "Sci-Fi"
            };
            catlist.Add(scifi);
            
            var action = new Category()
            {
                Name = "Action"
            };
            catlist.Add(action);

            context.AddRange(catlist);

            #endregion

            #region Medias

            var medialist = new List<Media>();

            #region Films

            var inception = new Media()
            {
                MediaType = MediaType.Film,
                Name = "Inception",
                Year = 2010,
                Description = "Cobb steals information from his targets by entering their dreams. Saito offers to wipe clean Cobb's criminal history as payment for performing an inception on his sick competitor's son.",
                Studio = warnerBros,
                Director = crisNolan,
                Reviews = {},
                ChildMedias = null
            };
            medialist.Add(inception);

            #endregion


            context.Medias.AddRange(medialist);
            #endregion


            context.SaveChanges();
        }

            private static async Task CreateIfNotExsits(
                                    RoleManager<Role> roleManager,
                                    Role role)
        {
            if (await roleManager.FindByNameAsync(role.Name) == null)
            {
                await roleManager.CreateAsync(role);
            }
        }
    }
}
