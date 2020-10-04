using System.Collections.Generic;
using System.Threading.Tasks;
using MediaTracking.BLL.DTOs;

namespace MediaTracking.BLL.Services.IServices
{
    public interface IUserService
    {
        Task<UserDTO> GetAsync(string id);
        Task DeleteAsync(string id);        
        Task<IEnumerable<UserDTO>> GetRangeAsync(uint offset, uint amount);
        Task<UserDTO> CreateAsync(UserDTO value);
        Task<UserDTO> UpdateAsync(UserDTO value);
        Task<UserDTO> UpdatePasswordAsync(UserDTO user, string newPassword);
        void UpdateCurrentUserId(string newValue);
    }
}