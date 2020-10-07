using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaTracking.BLL.DTOs;
using MediaTracking.BLL.Factories;
using MediaTracking.BLL.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IServiceFactory serviceFactory)
        {
            _userService = serviceFactory.UserService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            if (!String.IsNullOrEmpty(id))
                return Json(await _userService.GetAsync(id));
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDTO userDTO)
        {
            return userDTO != null 
                ? (IActionResult)Json(await _userService.CreateAsync(userDTO)) 
                : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}
