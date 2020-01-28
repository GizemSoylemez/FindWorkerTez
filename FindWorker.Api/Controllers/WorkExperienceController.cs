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
    public class WorkExperienceController : ControllerBase
    {
        private IUnitOfWork uow;
        public WorkExperienceController()
        {
            uow = new EfUnitOfWork(new FindWorkersTezContext());
        }

        [HttpGet]
        public IActionResult GetWorkExperience()
        {
            try
            {
                var result = uow.WorkExperiences.GetAll()?.ToList();
                if (result != null)
                    return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("error");
        }

        [HttpPost("AddWorkExperience")]
        public IActionResult AddWorkExperience([FromBody] WorkExperience entity)
        {
            uow.WorkExperiences.Post(entity);
            uow.SaveChanges();
            return Ok("ok");
        }

        [HttpPost("UpdateWorkExperience")]
        public IActionResult UpdateWorkExperience([FromBody] WorkExperience entity)
        {
            var result = uow.WorkExperiences.Get(Convert.ToInt32(entity.Id));
            result.CompanyName = entity.CompanyName;
            result.Description = entity.Description;
            result.Position = entity.Position;
            result.WorkFinishTime = entity.WorkFinishTime;
            result.WorkStartTime = entity.WorkStartTime;
            uow.WorkExperiences.Put(result);
            uow.SaveChanges();
            return Ok();
        }

        [HttpGet("delete")]
        public IActionResult RemoveWorkExperience(int id)
        {
            uow.WorkExperiences.Delete(uow.WorkExperiences.Get(id));
            uow.SaveChanges();
            return Ok("ok");
        }
    }
}