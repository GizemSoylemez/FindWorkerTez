using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FindWorker.Api.Models;
using FindWorker.Data.Abstract;
using FindWorker.Data.Concrete.Ef;
using FindWorker.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Test;

namespace FindWorker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUnitOfWork uow;

        public AuthController()
        {
            uow = new EfUnitOfWork(new FindWorkersTezContext());
        }
        [HttpPost]
        [Route("UserLogin")]
        public IActionResult UserLogin([FromBody] Login model )
        {
            var result = uow.Users.Find(i => i.Email == model.Email && i.Password == model.Password && i.RoleId==1).FirstOrDefault();
            if(result !=null)
            {
                var claims = new[]
                {
                     new Claim(JwtRegisteredClaimNames.Sub,model.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };

                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey"));

                var token = new JwtSecurityToken(
                    issuer: "http://cbank.com",
                    audience: "http://cbank.com",
                    expires: DateTime.UtcNow.AddHours(1),
                    claims: claims,
                    signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)

                    );

                return Ok(
                   new
                   {
                       token = new JwtSecurityTokenHandler().WriteToken(token),
                       expiration = token.ValidTo
                   }
                   );
            }
            return Unauthorized();
        }

        

        [HttpPost]
        [Route("CompanyLogin")]
        public IActionResult CompanyLogin([FromBody] Login model)
        {
            var result = uow.Companies.Find(i => i.CompanyEmail == model.Email && i.Password == model.Password && i.RoleId==2).FirstOrDefault();
            if (result != null)
            {
                var claims = new[]
                {
                     new Claim(JwtRegisteredClaimNames.Sub,model.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };

                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey"));

                var token = new JwtSecurityToken(
                    issuer: "http://cbank.com",
                    audience: "http://cbank.com",
                    expires: DateTime.UtcNow.AddHours(1),
                    claims: claims,
                    signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)

                    );

                return Ok(
                   new
                   {
                       token = new JwtSecurityTokenHandler().WriteToken(token),
                       expiration = token.ValidTo
                   }
                   );
            }
            return Unauthorized();
        }
    }
}