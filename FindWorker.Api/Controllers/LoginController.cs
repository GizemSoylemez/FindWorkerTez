using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FindWorker.Api.Models;
using FindWorker.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FindWorker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private UserManager<Role> userManager;
        public LoginController(UserManager<Role> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            var user = await userManager.FindByNameAsync(model.Email);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);//bu rollere ait userları ekledik
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.RoleId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var role in userRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }


                var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AspNetCoreDersim"));

                var token = new JwtSecurityToken(
                    issuer: "https://localhost:44396",
                    audience: "https://localhost:44396",
                    expires: DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc).AddHours(1),
                    claims: claims,
                    signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    message = "Giriş Başarılı"
                });
            }
            else
            {
                return BadRequest(new
                {
                    message = "kullanıcı adı ve parola yanlış"
                });
            }
        }

    }
}