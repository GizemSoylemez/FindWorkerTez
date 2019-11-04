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
    public class UserController : ControllerBase
    {
        private IUnitOfWork uow;

        public UserController()
        {
            uow = new EfUnitOfWork(new FindWorkersTezContext());
        }
        [HttpPost]
        public IActionResult AddUser(User entity)
        {
            var id = Request.Headers["id"];
            try
            {
                var rol = uow.Roles.Get(entity.Id);
                entity.Role = rol;
                uow.Users.Post(entity);
                uow.SaveChanges();
                return Ok(rol);
            }
            catch
            {
                return BadRequest("Bilinmeyen bir hata meydana geldi.");
            }

        }
       /* [HttpPost("")]
        public IActionResult UserLogin([FromBody]User entity)
        {
            try
            {
                var result = uow.Users.Find(i => i.Password == entity.Password && i.Email == entity.Email).FirstOrDefault();
                if (result != null)
                    return Ok("ok");
                else
                    return BadRequest("error");
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }*/
        [HttpPost("register")]
        public IActionResult Register([FromBody]User entity)
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
        [HttpGet("get")]
        public IActionResult GetUser()
        {
            //var id=Request.Headers["userId"];
            try
            {
                var result = uow.Users.GetAll()?.ToList();
                if (result != null)
                    return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("Error");
        }



        [HttpPut("")]
        public IActionResult UpdateUser([FromBody]User entity)
        {
            //var id = Request.Headers["userId"];


            try
            {
                var result = uow.Users.Find(i => i.Id == entity.Id);
                //entity.Role = uow.Roles.Get(entity.RoleId);
                uow.Users.Put(entity);
                uow.SaveChanges();
                return Ok("ok");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("delete")]
        public IActionResult DeleteUser([FromBody] int Id)
        {
            // var id = Request.Headers["id"];
            try
            {
                var user = uow.Users.Get(Convert.ToInt32(Id));
                uow.Users.Delete(user);
                uow.SaveChanges();
                return Ok("ok");
                //var company = uow.Users.Get(company.Id);
                // uow.Users.Delete(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}