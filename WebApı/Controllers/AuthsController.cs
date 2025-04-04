using Business;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJwtHelper _jwtHelper;

        public AuthsController(IAuthService authService,IJwtHelper jwtHelper)
        {
            _authService = authService;
            _jwtHelper = jwtHelper; 
        }

        [HttpPost("register")]
        public IActionResult Register(UserRegisterDto userForRegisterDto)
        {
            var result = _authService.Register(userForRegisterDto);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDto userForLoginDto)
        {
            var result = _authService.Login(userForLoginDto);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("refresh-token")]
        public IActionResult RefreshToken([FromBody] RefreshTokenDto refreshTokenDto)
        {
            var result = _jwtHelper.RefreshToken(refreshTokenDto.RefreshToken);
            if (result.Success)
            {
                return Ok(new { AccessToken = result.Data });
            }
            return BadRequest(result.Message);
        }


    }
}
