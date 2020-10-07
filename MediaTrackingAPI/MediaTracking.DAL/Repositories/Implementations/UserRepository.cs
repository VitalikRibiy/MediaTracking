using MediaTracking.DAL.Context;
using MediaTracking.DAL.Models.Authentication;
using MediaTracking.DAL.Repositories.IRepositories;
using System.Threading.Tasks;

namespace MediaTracking.DAL.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly MediaTrackingDbContext _dbContext;

        public UserRepository(MediaTrackingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<ApplicationUser> AddAsync(ApplicationUser entity)
        {
            return (await _dbContext.AddAsync(entity)).Entity;
        }

        public string CurrentUserId
        {
            get => _dbContext.CurrentUserId;
            set => _dbContext.CurrentUserId = value;
        }
    }
}