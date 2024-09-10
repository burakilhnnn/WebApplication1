using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using Domain.Entities;
using Persistence.Context;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly AppDbContext _context;

        public AuthController(IOptions<JwtSettings> jwtSettings, AppDbContext context)
        {
            _jwtSettings = jwtSettings.Value;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("Giris")]
        public async Task<IActionResult> Giris([FromBody] UserLoginModel userLoginModel)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Email.ToLower() == userLoginModel.Email.ToLower());

            if (user == null)
                return NotFound("Kullanıcı bulunamadı");

            if (user.Password != userLoginModel.Password)
            {
                return Unauthorized("Şifre yanlış");
            }

            var token = CreateToken(user);
            return Ok(new { Token = token });
        }



        private string CreateToken(User user)
        {
            if (_jwtSettings.Key == null)
                throw new Exception("JWT ayarlarında Key değeri null olamaz");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var dbRoles = _context.Roles.ToList();
            bool isAdmin = false;
            foreach (var item in user.Roles)
            {
                var role = dbRoles.FirstOrDefault(x => x.Id == item && x.Name == "admin");
                isAdmin = role != null;
            }


            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Role, isAdmin ? "admin" : "user")
            };




            var token = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

       
    }
}
