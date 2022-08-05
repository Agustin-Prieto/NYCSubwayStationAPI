using Microsoft.AspNetCore.Mvc;
using NYCSubwayStationAPI.Models;
using NYCSubwayStationAPI.Services.Interfaces;

namespace NYCSubwayStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _authService.Login(model);

            return Ok(user);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationModel model)
        {
            var userRegistered = await _authService.Register(model);

            return Ok(userRegistered);
        }

        [HttpPost]
        [Route("registerAdmin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegistrationModel model)
        {
            var userRegistered = await _authService.RegisterAdmin(model);

            return Ok(userRegistered);
        }
    }
}
