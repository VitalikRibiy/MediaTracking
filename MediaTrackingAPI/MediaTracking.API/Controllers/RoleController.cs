using MediaTracking.BLL.DTOs;
using MediaTracking.BLL.Factories;
using MediaTracking.BLL.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaTracking.API.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IServiceFactory serviceFactory)
            : base()
        {
            _roleService = serviceFactory.RoleService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RoleDTO roleDTO)
        {
            return roleDTO != null
                ? (IActionResult)Json(await _roleService.CreateAsync(roleDTO))
                : BadRequest();
        }
    }
}
