using System.Threading.Tasks;
using MediaTracking.BLL.DTOs;

namespace MediaTracking.BLL.Services.IServices
{
    public interface IAuthenticationService
    {
        Task<TokenDTO> SignInAsync(LoginDTO credentials);
        Task<TokenDTO> TokenAsync(TokenDTO token);
    }
}