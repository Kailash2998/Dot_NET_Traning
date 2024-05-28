using JwtAuthentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace JwtAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        private Users AuthenticateUser(Users user)
        {
            Users _user = null;
            if(user.Username == "admin" && user.Password == "12345") { 
               _user = new Users { Username = "kailash"};
            }
            return _user;
        }

        private String GenerateToken(Users user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
             var token = new JwtSecurityToken(_config["jwt:Issuer"], _config["jwt:Audience"],null,
                expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(Users user)
        {
            IActionResult response = Unauthorized();
            var user_ =     AuthenticateUser(user); 
            if (user_ != null)
            {
                var token = GenerateToken(user_);
                response = Ok(new
                {
                    token = token
                });
            }
            return response;
        }
    }
}
