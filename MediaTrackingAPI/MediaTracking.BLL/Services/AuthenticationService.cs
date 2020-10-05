using System;
using System.Linq;
using System.Threading.Tasks;
using MediaTracking.BLL.DTOs;
using MediaTracking.BLL.Factories;
using MediaTracking.BLL.Services.IServices;
using MediaTracking.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace MediaTracking.BLL.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtFactory _jwtFactory;

        public AuthenticationService(
            IJwtFactory jwtFactory,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _jwtFactory = jwtFactory;
        }

        public async Task<TokenDTO> SignInAsync(LoginDTO credentials)
        {
            try
            {
                var user = (await _unitOfWork.UserManager.FindByNameAsync(credentials.Login));

                if (user != null && (bool)user.IsActive && (await _unitOfWork.UserManager.CheckPasswordAsync(user, credentials.Password)))
                {
                    var role = (await _unitOfWork.UserManager.GetRolesAsync(user)).SingleOrDefault();
                    var token = _jwtFactory.GenerateToken(user.Id, user.UserName, role); 
                    return token;
                }
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<TokenDTO> TokenAsync(TokenDTO token)
        {
            try
            {
                var user = await _unitOfWork.UserManager.FindByIdAsync(
                        _jwtFactory.GetPrincipalFromExpiredToken(token.AccessToken).jwt.Subject
                        );
                var role = (await _unitOfWork.UserManager.GetRolesAsync(user)).SingleOrDefault();
                var newToken = _jwtFactory.GenerateToken(user.Id, user.UserName, role);

                return newToken;
            }
            catch (Exception e)
                when (e is SecurityTokenException || e is DbUpdateException)
            {
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}