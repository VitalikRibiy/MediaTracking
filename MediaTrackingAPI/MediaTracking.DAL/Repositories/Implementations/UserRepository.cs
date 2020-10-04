using MediaTracking.DAL.Context;
using MediaTracking.DAL.Repositories.IRepositories;

namespace MediaTracking.DAL.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly MediaTrackingDbContext _dbContext;

        public UserRepository(MediaTrackingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string CurrentUserId
        {
            get => _dbContext.CurrentUserId;
            set => _dbContext.CurrentUserId = value;
        }
    }
}