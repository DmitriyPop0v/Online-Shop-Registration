using Atuhorization.auth;
using Authorization.auth;
using Authorization.Repository;
using Authrorization.auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authorization.Controllers
{
    [ApiController]
    [Route("user")]
    
    public class AuthorizationController:ControllerBase
    {
        private IUserRepository _userRepository;
        private ITokenService _tokenService;
        public AuthorizationController(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Authorize([FromBody]UserDto user)
        { 
            var userDto = await _userRepository.GetUser(user);
            if (userDto == null)
                return new UnauthorizedResult();
            var token = _tokenService.BuildToken("V545rat5451111111111111111111111111111122222222222222222233333333333333333333344444444444444444", "Vitaliy", userDto);
           return new OkObjectResult(token);
           
        }
        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] UserModel user)
        {
            await _userRepository.InsertUser(user);
            await _userRepository.SaveAsync();
            return new CreatedResult("/user/login",user);
        }
    }
}
