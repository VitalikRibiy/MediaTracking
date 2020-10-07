using System.Threading.Tasks;
using MediaTracking.DAL.Context;
using MediaTracking.DAL.Models.Authentication;
using MediaTracking.DAL.Repositories.IRepositories;
using Microsoft.AspNetCore.Identity;

namespace MediaTracking.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MediaTrackingDbContext _context;

        public UserManager<ApplicationUser> UserManager { get;}

        public IUserRepository UserRepository {get;}

        public RoleManager<Role> RoleManager { get; }

        public UnitOfWork(
                MediaTrackingDbContext context,
                UserManager<ApplicationUser> userManager,
                IUserRepository userRepository,
                RoleManager<Role> roleManager)
        {
            _context = context;
            UserManager = userManager;
            UserRepository = userRepository;
            RoleManager = roleManager;
        }
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}