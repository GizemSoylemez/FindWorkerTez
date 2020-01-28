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
    public class ContactController : ControllerBase
    {
        private IUnitOfWork uow;
        public ContactController()
        {
            uow = new EfUnitOfWork(new FindWorkersTezContext());
        }
        [HttpPost("AddContact")]
        public IActionResult AddContact([FromBody]Contact entity)
        {
            // var id = Request.Headers["id"];
            try
            {
                entity.CreationDate = DateTime.Now;
                uow.Contacts.Post(entity);
                uow.SaveChanges();
                return Ok("OK");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("")]
        public IActionResult GetContact()
        {
            //var id=Request.Headers["languageId"];
            try
            {
                var result = uow.Contacts.GetAll()?.ToList();
                if (result != null)
                    return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("Error");
        }
        [HttpPost("UpdateContact")]
        public IActionResult UpdateContact([FromBody]Contact entity)
        {
            try
            {
                var result = uow.Contacts.Get(Convert.ToInt32(entity.Id));
                // var result2 = uow.Projects.Find(i => i.UserId == entity.UserId);
                //Project uProject = entity;
                //uProject.Id = result.Id;
                result.ContactName = entity.ContactName;
                result.Decription = entity.Decription;
                uow.Contacts.Put(result);
                uow.SaveChanges();
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest("Error");
            }

        }
        [HttpGet("delete")]
        public IActionResult DeleteContact()
        {
            var id = Request.Headers["id"];

            try
            {
                var contact = uow.Contacts.Get(Convert.ToInt32(id));
                uow.Contacts.Delete(contact);
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
    