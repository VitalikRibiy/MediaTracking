using AutoMapper;
using MediaTracking.BLL.DTOs;
using MediaTracking.BLL.Services.IServices;
using MediaTracking.DAL.Models.Authentication;
using MediaTracking.DAL.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediaTracking.BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<RoleDTO> CreateAsync(RoleDTO value)
        {
            var role = _mapper.Map<Role>(value);
            IdentityResult result = await _unitOfWork.RoleManager.CreateAsync(role);
            return result.Succeeded ? _mapper.Map<RoleDTO>(role) : null;
        }
    }
}
