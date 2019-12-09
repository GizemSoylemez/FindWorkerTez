using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindWorker.Data.Abstract;
using FindWorker.Data.Concrete.Ef;
using FindWorker.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindWorker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private IUnitOfWork uow;

        public RegisterController()
        {
            uow = new EfUnitOfWork(new FindWorkersTezContext());
        }
        [HttpPost("RegisterCompany")]
        public IActionResult Company([FromBody]Company entity)
        {
            var result = uow.Companies.Find(i => i.CompanyEmail == entity.CompanyEmail).FirstOrDefault();
            if (result != null)
            {
                return BadRequest("error");
            }
            else
            {
                entity.CreationDate = DateTime.Now;
                var rol = uow.Roles.Find(i => i.RoleId == 2).FirstOrDefault();
                entity.role = rol;

                uow.Companies.Post(entity);
                uow.SaveChanges();
                return Ok("ok");
            }
        }
        [HttpPost("RegisterUser")]
        public IActionResult User([FromBody]User entity)
        {
            try
            {
                var result = uow.Users.Find(i => i.Email == entity.Email).FirstOrDefault();
                if (result != null)
                {
                    return BadRequest("error");
                }
                else
                {
                    entity.CreationDate = DateTime.Now;
                    var rol = uow.Roles.Find(i => i.RoleId == 1).FirstOrDefault();
                    entity.Role = rol;

                    uow.Users.Post(entity);
                    uow.SaveChanges();
                    return Ok("OK");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}