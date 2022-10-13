using BusinessObject.DataAccess;
using BusinessObject.ResponseModel;
using MamCo.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MamCo.Controllers.LoginController
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly foodappContext _context;
        private readonly AppSettings _appSettings;
        public LoginController(foodappContext context,IOptionsMonitor<AppSettings> optionsMonitor)
        {
            _context = context;
            _appSettings = optionsMonitor.CurrentValue;
        }
        [HttpPost]
        public IActionResult Validate(LoginModel model)
        {
            var user = _context.Users.SingleOrDefault(p => p.Username == model.Username && model.Password == p.Password);
            var roleuser = _context.UsersRoles.FirstOrDefault(p => p.UserId == user.UserId);
            string Role = _context.Roles.FirstOrDefault(p => p.RoleId == roleuser.RoleId).Name;
            if (user == null)
            {
                return Ok(new ApiResponse {
                    Success=false,
                    Message="Invalid user"
                });
            }
            return Ok(new ApiResponse
            {
                Success = true,
                Message="Authenticate success",
                Data= GenerateToken(user,Role)
            }) ;
        }
        private string GenerateToken(User user,string Role)
        {
            var JwtTokenHandler = new JwtSecurityTokenHandler();

            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);    
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Role,Role),
                    new Claim(ClaimTypes.Name,user.Username),
                    new Claim("Status",user.Enabled.ToString()),
                    new Claim("Id",user.UserId.ToString()),
                    new Claim("TokenId",Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials =new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes)
                , SecurityAlgorithms.HmacSha256Signature)
            };
            var token = JwtTokenHandler.CreateToken(tokenDescription);
            return JwtTokenHandler.WriteToken(token);
        }
    }
}
