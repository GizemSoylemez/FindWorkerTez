using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FindWorker.Data.Abstract;
using FindWorker.Data.Concrete.Ef;
using FindWorker.Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindWorker.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IUnitOfWork uow;
        public UserController()
        {
            uow = new EfUnitOfWork(new FindWorkersTezContext());

        }

        [HttpGet]
        public IActionResult GetUser()
        {
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

        [Route("GetLoginUser")]
        [HttpGet]
        public IActionResult GetLoginUser()
        {
            var email = User.Claims.FirstOrDefault().Value;
            return Ok(uow.Users.Find(x => x.Email == email).FirstOrDefault());
        }


        /*[HttpPost]
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
           

        }*/
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
        public IActionResult DeleteUser()
        {
            try
            {
                var id = Request.Headers["id"];
                var user = uow.Users.Get(Convert.ToInt32(id));
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


        [HttpGet("GetUserInfo")]
        public IActionResult GetUserInfo()
        {
            var email = User.Claims.FirstOrDefault().Value;
            var usr = uow.Users.Find(i => i.Email == email).FirstOrDefault();
            Cv cv = new Cv();

            User user = new User();
            try
            {

                cv.Contact = uow.Contacts.Find(i => i.UserId == usr.Id).ToList();
                cv.CvData = uow.CvDatas.Find(i => i.UserId == usr.Id).ToList();
                cv.Document = uow.Documents.Find(i => i.UserId == usr.Id).ToList();
                cv.Education = uow.Educations.Find(i => i.UserId == usr.Id).ToList();
                cv.Hobby = uow.Hobbies.Find(i => i.UserId == usr.Id).ToList();
                cv.Language = uow.Languages.Find(i => i.UserId == usr.Id).ToList();
                cv.Location = uow.Locations.Find(i => i.UserId == usr.Id).ToList();
                cv.Project = uow.Projects.Find(i => i.UserId == usr.Id).ToList();
                cv.Reference = uow.References.Find(i => i.UserId == usr.Id).ToList();
                cv.Skill = uow.Skills.Find(i => i.UserId == usr.Id).ToList();
                //cv.WorkExperience = uow.WorkExperiences.Find(i => i.UserId == usr.Id).ToList();
                return Ok(cv);

            }


            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Photo")]
        public async Task<IActionResult> UpdatePhoto([FromForm]User entity, IFormFile file)
        {
           
            if (file != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "node_modules\\images", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);

                    entity.ProfilePhoto = file.FileName;
                }

                uow.Users.Post(entity);
                uow.SaveChanges();
              

         


            }
            return Ok();

        }
    }
}

