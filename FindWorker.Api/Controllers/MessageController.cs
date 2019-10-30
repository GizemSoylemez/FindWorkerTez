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
    public class MessageController : ControllerBase
    {
        private IUnitOfWork uow;
        public MessageController()
        {
            uow = new EfUnitOfWork(new FindWorkersTezContext());
        }


        [HttpGet]
        public IActionResult GetMessage()
        {
            try
            {
                var result = uow.Messages.GetAll()?.ToList();
                if (result != null)
                    return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("error");
        }
        
        [HttpPost]
        public IActionResult AddMessage([FromBody] Message entity)
        {
            uow.Messages.Post(entity);
            uow.SaveChanges();
            return Ok("ok");
        }

        [HttpPut]
        public IActionResult UpdateMessage([FromBody] Message entity)
        {
            uow.Messages.Put(entity);
            uow.SaveChanges();
            return Ok("ok");
        }

        [HttpGet("delete")]
        public IActionResult RemoveMessage(int id)
        {
            uow.Messages.Delete(uow.Messages.Get(id));
            uow.SaveChanges();
            return Ok("ok");
        }
    }
}