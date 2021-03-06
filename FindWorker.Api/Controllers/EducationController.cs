﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindWorker.Data.Abstract;
using FindWorker.Data.Concrete.Ef;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FindWorker.Entity.Models;

namespace FindWorker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private IUnitOfWork uow;

        public EducationController()
        {
            uow = new EfUnitOfWork(new FindWorkersTezContext());
        }

        [HttpGet]
        public IActionResult GetEducation()
        {
            try
            {
                var result = uow.Educations.GetAll()?.ToList();
                if (result != null)
                    return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
            return BadRequest("error");
        }

        [HttpPost("AddEducation")]
        public IActionResult AddEducation([FromBody] Education entity)
        {
            uow.Educations.Post(entity);
            uow.SaveChanges();
            return Ok("ok");
        }

        [HttpPost("UpdateEducation")]
        public IActionResult UpdateEducation([FromBody] Education entity)
        {
            var result = uow.Educations.Get(Convert.ToInt32(entity.Id));
            result.SchoolName = entity.SchoolName;
            result.GruadetDate = entity.GruadetDate;
            result.Department = entity.Department;
            uow.Educations.Put(result);
            uow.SaveChanges();
            return Ok();
        }
        [HttpGet("delete")]
        public IActionResult RemoveEducation(int id)
        {
            uow.Educations.Delete(uow.Educations.Get(id));
            uow.SaveChanges();
            return Ok("ok");
        }
    }
}