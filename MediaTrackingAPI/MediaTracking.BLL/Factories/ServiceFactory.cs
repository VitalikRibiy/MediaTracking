using MediaTracking.BLL.Services.IServices;

namespace MediaTracking.BLL.Factories
{
    public class ServiceFactory : IServiceFactory
    {
        public IAuthenticationService AuthenticationService { get; }

        public IUserService UserService { get; }

        public ServiceFactory(
            IAuthenticationService authenticationService,
            IUserService userService)
        {
            AuthenticationService = authenticationService;
            UserService = userService;
        }
    }    
}