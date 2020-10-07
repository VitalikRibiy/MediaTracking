using MediaTracking.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediaTracking.BLL.Services.IServices
{
    public interface IRoleService
    {
        Task<RoleDTO> CreateAsync(RoleDTO value);
    }
}
