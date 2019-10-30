using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindWorker.Data.Abstract;
using FindWorker.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FindWorker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUnitOfWork uow;

        public UserController(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        [HttpPost]
        public String AddUser( User entity)
        {
            var rol = uow.Roles.Get(entity.RoleId);
            entity.role = rol;
            uow.Users.Post(entity);
            uow.SaveChanges();
            return "Ok";
        }
     
        [HttpPost]
        public bool Register(User entity)
        {
            var result = uow.Users.Find(i => i.Email == entity.Email).FirstOrDefault();

            if (result != null)
            {
                return false;
            }
            else
            {
                entity.CreationDate = DateTime.Now;
                var rol = uow.Roles.Find(i => i.RoleId == 2).FirstOrDefault();
                entity.role = rol;

                uow.Users.Post(entity);
                uow.SaveChanges();
                return true;
            }
        }
        
        [HttpPost]
        public bool UpdateUser(User entity)
        {
            entity.role = uow.Roles.Get(entity.RoleId);
            uow.Users.Put(entity);
            uow.SaveChanges();
            return true;
        }

       
    }
  
}