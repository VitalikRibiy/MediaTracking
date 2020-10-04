using System.Threading.Tasks;
using MediaTracking.DAL.Models.Authentication;
using MediaTracking.DAL.Repositories.IRepositories;
using Microsoft.AspNetCore.Identity;

namespace MediaTracking.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        UserManager<ApplicationUser> UserManager {get;}
        IUserRepository UserRepository {get;}
        Task<int> SaveChangesAsync();
    }
}