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
    public class DocumentController : ControllerBase
    {
        private IUnitOfWork uow;
        public DocumentController()
        {
            uow = new EfUnitOfWork(new FindWorkersTezContext());
        }
        [HttpPost("AddDocument")]
        public IActionResult AddDocument([FromBody]Document entity)
        {
            // var id = Request.Headers["documentid"];
            try
            {
                entity.CreationDate = DateTime.Now;
                uow.Documents.Post(entity);
                uow.SaveChanges();
                return Ok("OK");

            }
            catch (Exception ex)
            {
                return BadRequest("error");
            }

        }

        [HttpGet("")]
        public IActionResult GetDocument()
        {
            //var id=Request.Headers["documentId"];
            try
            {
                var result = uow.Documents.GetAll()?.ToList();
                if (result != null)
                    return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("Error");
        }
        [HttpPost("UpdateDocument")]
        public IActionResult UpdateDocument([FromBody]Document entity)
        {
            try
            {
                var result = uow.Documents.Get(Convert.ToInt32(entity.Id));
                result.DocumentationName = entity.DocumentationName;
                result.DocumentDate = entity.DocumentDate;
                uow.Documents.Put(result);
                uow.SaveChanges();
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest("Error");
            }

        }
        [HttpGet("delete")]
        public IActionResult DeleteDocument()
        {
            var id = Request.Headers["id"];

            try
            {
                var document = uow.Documents.Get(Convert.ToInt32(id));
                uow.Documents.Delete(document);
                uow.SaveChanges();
                return Ok("ok");
                //var company = uow.Users.Get(company.Id);
                // uow.Users.Delete(user);
            }
            catch (Exception ex)
            {
                return BadRequest("Error");
            }
        }
    }
}