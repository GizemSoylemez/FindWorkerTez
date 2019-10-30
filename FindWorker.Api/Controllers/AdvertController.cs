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
    public class AdvertController : ControllerBase
    {
        private IUnitOfWork uow;
        public AdvertController()
        {
            uow = new EfUnitOfWork(new FindWorkersTezContext());
        }

        [HttpGet]
        public IActionResult GetAdvert()
        {
            try
            {
                var result = uow.Adverts.GetAll()?.ToList();
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
        public IActionResult AddAdvert([FromBody] Advert entity)
        {
            uow.Adverts.Post(entity);
            uow.SaveChanges();
            return Ok("ok");
        }

        [HttpPut]
        public IActionResult UpdateAdvert([FromBody] Advert entity)
        {
            uow.Adverts.Put(entity);
            uow.SaveChanges();
            return Ok("ok");
        }

        [HttpGet("delete")]
        public IActionResult RemoveAdvert(int id)
        {
            uow.Adverts.Delete(uow.Adverts.Get(id));
            uow.SaveChanges();
            return Ok("ok");
        }
    }
}