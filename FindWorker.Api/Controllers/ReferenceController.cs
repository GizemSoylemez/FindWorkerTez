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
    public class ReferenceController : ControllerBase
    {
        private IUnitOfWork uow;
        public ReferenceController()
        {
            uow = new EfUnitOfWork(new FindWorkersTezContext());
        }

        [HttpGet]
        public IActionResult GetReference()
        {
            try
            {
                var result = uow.References.GetAll()?.ToList();
                if (result != null)
                    return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return BadRequest("Error");
        }

        [HttpPost("AddReference")]
        public IActionResult AddReference([FromBody] Reference entity)
        {
            uow.References.Post(entity);
            uow.SaveChanges();
            return Ok("ok");
        }

        [HttpPut]
        public IActionResult UpdateRefernece([FromBody] Reference entity)
        {
            uow.References.Put(entity);
            uow.SaveChanges();
            return Ok("ok");
        }

        [HttpGet("delete")]
        public IActionResult RemoveReference(int id)
        {
            uow.References.Delete(uow.References.Get(id));
            uow.SaveChanges();
            return Ok("ok");
        }
    }
}