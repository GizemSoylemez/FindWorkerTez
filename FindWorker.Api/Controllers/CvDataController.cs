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
    public class CvDataController : ControllerBase
    {
        private IUnitOfWork uow;
        public CvDataController()
        {
            uow = new EfUnitOfWork(new FindWorkersTezContext());
        }

        [HttpGet("")]
        public IActionResult GetCvData()
        {
            try
            {
                var result = uow.CvDatas.GetAll()?.ToList();
                if (result != null)
                    return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return BadRequest("Error");
        }

        [HttpPost("AddCvName")]
       public IActionResult AddCv(Cvdata entity)
        {
            try
            {
                uow.CvDatas.Post(entity);
                uow.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            
        }

        [HttpPut]
        public IActionResult UpdateCv(Cvdata entity)
        {
            uow.CvDatas.Put(entity);
            uow.SaveChanges();
            return Ok();
        }

        [HttpGet("Delete")]
        public bool RemoveCv(int id)
        {
            uow.CvDatas.Delete(uow.CvDatas.Get(id));
            uow.SaveChanges();
            return true;
        }

    }
}