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
    public class LanguageController : ControllerBase
    {
        private IUnitOfWork uow;
        public LanguageController()
        {
            uow = new EfUnitOfWork(new FindWorkersTezContext());
        }
        [HttpPost("AddLanguage")]
        public IActionResult AddLanguage([FromBody]Language entity)
        {
            // var id = Request.Headers["id"];
            try
            {
                entity.CreationDate = DateTime.Now;
                uow.Languages.Post(entity);
                uow.SaveChanges();
                return Ok("OK");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("")]
        public IActionResult GetLanguage()
        {
            //var id=Request.Headers["languageId"];
            try
            {
                var result = uow.Languages.GetAll()?.ToList();
                if (result != null)
                    return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("Error");
        }
        [HttpPost("UpdateLanguage")]
        public IActionResult UpdateLanguage([FromBody]Language entity)
        {
            try
            {
                var result = uow.Languages.Get(Convert.ToInt32(entity.Id));
                result.LanguageName = entity.LanguageName;
                result.LanguageLevel = entity.LanguageLevel;
                uow.Languages.Put(result);
                uow.SaveChanges();
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("delete")]
        public IActionResult DeleteLanguage()
        {
            var id = Request.Headers["id"];

            try
            {
                var document = uow.Languages.Get(Convert.ToInt32(id));
                uow.Languages.Delete(document);
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