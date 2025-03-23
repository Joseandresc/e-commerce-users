using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUsersService _usersService;
        //Constructor to inject the users service (singleton) 
        public AuthenticationController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        [HttpPost("register")] //Post /api/register
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            //Check for invalid registerRequest
            if (registerRequest == null)
            {
                return BadRequest("Invalid registration data");
            }
            AuthenticationResponse? authenticationResponse = await _usersService.Register(registerRequest);
            if (authenticationResponse == null || authenticationResponse.Success == false)
            {
                return BadRequest("Registration didn't succeed please try again");
            }
            return Ok(authenticationResponse);
        }
        [HttpPost("login")] //POST api/login
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if(loginRequest == null)
            {
                return BadRequest("Enter your credentials");
            }
            AuthenticationResponse? authenticationResponse = await _usersService.Login(loginRequest);

            if (authenticationResponse == null || authenticationResponse.Success == false)
            {
                return Unauthorized("Invalid credentials");
            }
            return Ok(authenticationResponse);
        
        }
    }
}
