using MediaTracking.BLL.Services.IServices;

namespace MediaTracking.BLL.Factories
{
    public interface IServiceFactory
    {
        IAuthenticationService AuthenticationService { get; }
        IUserService UserService { get; }
        IRoleService RoleService { get; }
    }
}