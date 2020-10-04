using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediaTracking.BLL.DTOs;
using MediaTracking.BLL.Services.IServices;
using MediaTracking.DAL.Models.Authentication;
using MediaTracking.DAL.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MediaTracking.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDTO> UpdateAsync(UserDTO model)
        {
            ApplicationUser user = await _unitOfWork.UserManager.FindByIdAsync(model.Id);
            IList<string> roles = await _unitOfWork.UserManager.GetRolesAsync(user);
            if (roles.Count > 0)
            {
                await _unitOfWork.UserManager.RemoveFromRoleAsync(user, roles.First());
            }

            await _unitOfWork.UserManager.AddToRoleAsync(user, model.Role.Name);
            user = _mapper.Map(model, user);
            IdentityResult updateResult = await _unitOfWork.UserManager.UpdateAsync(user);
            return updateResult.Succeeded ? _mapper.Map<UserDTO>(user) : null;
        }

        public virtual async Task<UserDTO> UpdatePasswordAsync(UserDTO user, string newPassword)
        {
            ApplicationUser entity = await _unitOfWork.UserManager.FindByIdAsync(user.Id);
            IdentityResult result = await _unitOfWork.UserManager.RemovePasswordAsync(entity);
            if (result.Succeeded)
            {
                result = await _unitOfWork.UserManager.AddPasswordAsync(entity, newPassword);
            }
            return result.Succeeded ? user : null;
        }

        public async Task<UserDTO> GetAsync(string id)
        {
            ApplicationUser entity = await _unitOfWork.UserManager.FindByIdAsync(id);
            return entity == null ? null : _mapper.Map<UserDTO>(entity);
        }

        public async Task<IEnumerable<UserDTO>> GetRangeAsync(uint offset, uint amount)
        {
            List<ApplicationUser> source = await _unitOfWork.UserManager.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .Skip((int)offset)
                .Take((int)amount)
                .ToListAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(source);
        }

        public async Task<UserDTO> CreateAsync(UserDTO value)
        {
            ApplicationUser user = _mapper.Map<ApplicationUser>(value);
            IdentityResult result = await _unitOfWork.UserManager.CreateAsync(user);
            if (result.Succeeded && value.Password != null)
            {
                result = await _unitOfWork.UserManager.AddPasswordAsync(user, value.Password);
            }
            if (result.Succeeded)
            {
                result = await _unitOfWork.UserManager.AddToRoleAsync(user, value.Role.Name);
            }
            return result.Succeeded ? _mapper.Map<UserDTO>(user) : null;
        }

        public async Task DeleteAsync(string id)
        {
            ApplicationUser user = await _unitOfWork.UserManager.FindByIdAsync(id);
            await _unitOfWork.UserManager.DeleteAsync(user);
        }

        public void UpdateCurrentUserId(string newValue)
        {
            _unitOfWork.UserRepository.CurrentUserId = newValue;
        }
    }
}