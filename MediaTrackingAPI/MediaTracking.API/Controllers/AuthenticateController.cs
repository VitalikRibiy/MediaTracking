using MediaTracking.BLL.DTOs;
using MediaTracking.BLL.Factories;
using MediaTracking.BLL.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IServiceFactory serviceFactory)
        {
            _authenticationService = serviceFactory.AuthenticationService;
        }

        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn([FromBody] LoginDTO credentials)
        {
            var result = await _authenticationService.SignInAsync(credentials);
            return result != null
                ? Json(result)
                : (IActionResult)BadRequest();
        }

        [HttpPost]
        [Route("refreshtoken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenDTO token)
        {
            var result = await _authenticationService.TokenAsync(token);
            return result != null
                ? Json(result)
                : (IActionResult)Forbid();
        }

    }
}  