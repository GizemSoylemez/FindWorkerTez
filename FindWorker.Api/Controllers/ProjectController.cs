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
    public class ProjectController : ControllerBase
    {
        private IUnitOfWork uow;
        public ProjectController()
        {
            uow = new EfUnitOfWork(new FindWorkersTezContext());
        }
        [HttpPost]
        public IActionResult AddProject([FromBody]Project entity)
        {
            // var id = Request.Headers["id"];
            try
            {
                entity.CreationDate = DateTime.Now;
                uow.Projects.Post(entity);
                uow.SaveChanges();
                return Ok("OK");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("")]
        public IActionResult GetProject()
        {
            //var id=Request.Headers["languageId"];
            try
            {
                var result = uow.Projects.GetAll()?.ToList();
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
        public IActionResult UpdateProject([FromBody]Project entity)
        {
            try
            {
                var result = uow.Projects.Find(i => i.Id == entity.Id);
                //entity.Role = uow.Roles.Get(entity.RoleId);
                uow.Projects.Put(entity);
                uow.SaveChanges();
                return Ok("ok");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("delete")]
        public IActionResult DeleteProject()
        {
            var id = Request.Headers["id"];

            try
            {
                var project = uow.Projects.Get(Convert.ToInt32(id));
                uow.Projects.Delete(project);
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