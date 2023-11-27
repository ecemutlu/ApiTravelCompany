using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using ApiTravelCompany.Dto;
using ApiTravelCompany.Models;
using ApiTravelCompany.Db;

namespace ApiTravelCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;
        private readonly TravelContext _context;
        public UserController(IConfiguration config, TravelContext context)
        {
            _config = config;
            _context = context;
        }
        /// <summary>
        /// Authenticates user and generates JWT token
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        [HttpPost]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserLoginDto userLogin)
        {
            var user = Authenticate(userLogin);

            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);
            }

            return NotFound("User not found");
        }

        private string Generate(User user)
        {
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey,
                Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User? Authenticate(UserLoginDto userLogin)
        {
            return _context.Users.FirstOrDefault(o => o.Username.ToLower() == userLogin.UserName.ToLower() && o.Password == userLogin.Password);
        }
    }
}

