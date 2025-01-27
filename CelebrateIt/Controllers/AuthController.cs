using System.Security.Authentication;
using CelebrateIt.DTOs.UserDTO;
using CelebrateIt.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CelebrateIt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        //Samruddhi

        [HttpPost("/register_user")]
        public IActionResult RegisterUser([FromBody] ReqUserRegistrationDTO dto)
        {
            //Binds the incoming HTTP request payload to the ReqUserRegistrationDTO object.
            string response = _authService.AddUser(dto);
            return Ok(response);
        }

        //Samruddhi
        [HttpPost]
        public IActionResult AuthUser([FromBody] ReqUserLoginDTO dto)
        {
            try
            {
                string token = _authService.AuthUserDetails(dto);
                return Ok(token);
            }
            catch (InvalidCredentialException e)
            {
                return Unauthorized(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = e.Message });
            }
        }

    }
}

        
       

    

