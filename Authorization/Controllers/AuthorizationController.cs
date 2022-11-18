using Atuhorization.auth;
using Authorization.auth;
using Authorization.Repository;
using Authrorization.auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Authorization.Controllers
{
    [ApiController]
    [Route("user")]

    public class AuthorizationController : ControllerBase
    {
        private IUserRepository _userRepository;
        private ITokenService _tokenService;
        public AuthorizationController(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        [HttpPost("login")]
        public async Task<string> Authorize([FromForm] UserDto user)
        {
            var userDto = await _userRepository.GetUser(user);
            if (userDto == null)
                return "не авторизован";
            var token = _tokenService.BuildToken("V545rat5451111111111111111111111111111122222222222222222233333333333333333333344444444444444444", "Vitaliy", userDto);
            return "Авторизован. Вот jwt токен: " + token;
        }
        [HttpPost("registration")]
        public async Task<string> Registration([FromForm] UserModel user)
        {
            string patternEmail = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))";
            string patternPhone = @"(\+7|8|\b)[\(\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[)\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)";
            string patternUserName = @"[А-Яа-я]";
            string password = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$";
            if (await _userRepository.GetUserLogin(user) != null)
            {
                return "This user exists";
            }
            if (user.Password != user.Repassword)
            {
                return "Password doesn't matches";
            }
            if (!Regex.IsMatch(user.Email, patternEmail, RegexOptions.IgnoreCase))
            {
                return "Email isn't correct";
            }
            if (!Regex.IsMatch(user.mobile, patternPhone, RegexOptions.IgnoreCase))
            {
                return "Mobile isn't correct";
            }
            if (!Regex.IsMatch(user.UserName, patternUserName))
            {
                return "Cyrillic  needs for First and Last Name";
            }
            if (!Regex.IsMatch(user.Password, password))
            {
                return "Password is weak";
            }
            if (user.Policy != false)
            {
                return "Choose policy";
            }

            string patterLogin = "[A-Za-z]";
            if (!Regex.IsMatch(user.Login, patterLogin))
            {
                return "Use latin alphabet for login";
            }
            

            await _userRepository.InsertUser(user);
            await _userRepository.SaveAsync();

            return "Вы зарегистрированы";
        }
    }
}
