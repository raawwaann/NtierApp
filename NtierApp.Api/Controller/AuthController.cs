using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NtierApp.Data;
using NtierApp.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
//using System.Web.Mvc;

namespace NtierApp.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        public readonly IConfiguration _Configuration;
        public AuthController(IConfiguration Configuration) 
        { 
            _Configuration = Configuration;
        }

        [HttpPost("register")]
        public ActionResult<User> Register(UserDto request)
        {
            string passwordHash =
                BCrypt.Net.BCrypt.HashPassword(request.password);
            user.username = request.username;
            user.passwordHash = passwordHash;
            return Ok(user);


        }
        [HttpPost("login")]
        public ActionResult<User> Login(UserDto request)
        {
            if (user.username != request.username) 
            {
                return BadRequest("User not found");
            }
            if (!BCrypt.Net.BCrypt.Verify(request.password, user.passwordHash))
            {
                return BadRequest("Wrong Password");
            }
            string token = CreateToken(user);
            return Ok(token);

        }
        private string CreateToken(User user) 
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.username)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _Configuration.GetSection("AppSettings:Token").Value!));
            var creds= new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token =new  JwtSecurityToken(
                claims:claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);
            var jwt=new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

    }
}
