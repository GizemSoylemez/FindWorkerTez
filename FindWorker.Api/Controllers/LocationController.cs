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
    public class LocationController : ControllerBase
    {
        private IUnitOfWork uow;
        public LocationController()
        {
            uow = new EfUnitOfWork(new FindWorkersTezContext());
        }
        [HttpPost]
        public IActionResult AddLocation([FromBody]Location entity)
        {
            // var id = Request.Headers["id"];
            try
            {
                entity.CreationDate = DateTime.Now;
                uow.Locations.Post(entity);
                uow.SaveChanges();
                return Ok("OK");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("")]
        public IActionResult GetLocation()
        {
            //var id=Request.Headers["languageId"];
            try
            {
                var result = uow.Locations.GetAll()?.ToList();
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
        public IActionResult UpdateLocation([FromBody]Location entity)
        {

            try
            {
                var result = uow.Locations.Find(i => i.Id == entity.Id);
                //entity.Role = uow.Roles.Get(entity.RoleId);
                uow.Locations.Put(entity);
                uow.SaveChanges();
                return Ok("ok");

            }
            catch (Exception ex)
            {
                return BadRequest("Error");
            }

        }
        [HttpGet("delete")]
        public IActionResult DeleteLocation()
        {
            var id = Request.Headers["id"];

            try
            {
                var location = uow.Locations.Get(Convert.ToInt32(id));
                uow.Locations.Delete(location);
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