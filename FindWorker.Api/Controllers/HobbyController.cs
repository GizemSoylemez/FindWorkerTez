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
    public class HobbyController : ControllerBase
    {
        private IUnitOfWork uow;
        public HobbyController()
        {
            uow = new EfUnitOfWork(new FindWorkersTezContext());
        }
        [HttpPost("AddHobby")]
        public IActionResult AddHobby([FromBody]Hobby entity)
        {
            // var id = Request.Headers["id"];
            try
            {
                entity.CreationDate = DateTime.Now;
                uow.Hobbies.Post(entity);
                uow.SaveChanges();
                return Ok("OK");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("")]
        public IActionResult GetHobby()
        {
            //var id=Request.Headers["hobbyId"];
            try
            {
                var result = uow.Hobbies.GetAll()?.ToList();
                if (result != null)
                    return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("Error");
        }
        [HttpPost("UpdateHobby")]
        public IActionResult UpdateHobby([FromBody]Hobby entity)
        {

            try
            {
                var result = uow.Hobbies.Get(Convert.ToInt32(entity.Id));
                result.HobbiesName = entity.HobbiesName;
                uow.Hobbies.Put(result);
                uow.SaveChanges();
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("delete")]
        public IActionResult DeleteHobby([FromBody]Hobby entity)
        {
            // var id = Request.Headers["id"];

            try
            {
                var hobby = uow.Hobbies.Get(entity.Id);
                uow.Hobbies.Delete(hobby);
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