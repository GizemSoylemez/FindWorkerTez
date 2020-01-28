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
    public class SkillController : ControllerBase
    {
        private IUnitOfWork uow;
        public SkillController()
        {
            uow = new EfUnitOfWork(new FindWorkersTezContext());
        }
        [HttpPost("AddSkill")]
        public IActionResult AddSkill([FromBody]Skill entity)
        {
            // var id = Request.Headers["id"];
            try
            {
                entity.CreationDate = DateTime.Now;
                uow.Skills.Post(entity);
                uow.SaveChanges();
                return Ok("OK");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("")]
        public IActionResult GetSkill()
        {
            //var id=Request.Headers["languageId"];
            try
            {
                var result = uow.Skills.GetAll()?.ToList();
                if (result != null)
                    return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("Error");
        }
        [HttpPost("UpdateSkill")]
        public IActionResult UpdateSkill([FromBody]Skill entity)
        {
            try
            {
                var result = uow.Skills.Get(Convert.ToInt32(entity.Id));
                result.SkillName = entity.SkillName;
                result.SkillLevel = entity.SkillLevel;
                uow.Skills.Put(result);
                uow.SaveChanges();
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest("Error");
            }

        }
        [HttpGet("delete")]
        public IActionResult DeleteSkill()
        {
            var id = Request.Headers["id"];

            try
            {
                var skill = uow.Skills.Get(Convert.ToInt32(id));
                uow.Skills.Delete(skill);
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