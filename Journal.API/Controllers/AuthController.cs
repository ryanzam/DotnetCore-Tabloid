using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Journal.Model;
using Journal.Repository.Model;
using Journal.Repository.Services.AuthServices;
using Journal.Repository.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace Journal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly IUserService _userService;
        public AuthController(AuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("login")]
        public ActionResult<AuthData> Login([FromBody]LoginModel loginModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = _userService.GetSingle(u => u.Email == loginModel.Email);

            if(user == null)
            {
                return BadRequest(new { email = "User with email doesn't exists!" });
            }

            var pwdValid = _authService.VerifyPassword(loginModel.Password, user.Password);
            if (!pwdValid)
            {
                return BadRequest(new { password = "Incorrect password!" });
            }

            return _authService.GetAuthData(user.Id.ToString());
        }

        [HttpPost("register")]
        public ActionResult<AuthData> Register([FromBody] RegisterModel registerModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var eUnique = _userService.isEmailUnique(registerModel.Email);
            if (!eUnique) 
                return BadRequest(new { email = "User with this email is already registered. Use another email." });

            var usrUnique = _userService.IsUsernameUnique(registerModel.Username);
            if (!usrUnique) 
                return BadRequest(new { username = "Username already exists. Choose another username" });

            var newUser = new User { Username =registerModel.Username, Email = registerModel.Email, Password=_authService.HashPassword(registerModel.Password)};

            _userService.CreateAsync(newUser);

            return Ok(newUser);
        }

    }
}
