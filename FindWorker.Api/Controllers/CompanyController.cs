using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FindWorker.Data.Abstract;
using FindWorker.Data.Concrete.Ef;
using FindWorker.Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindWorker.Api.Controllers
{
   
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private IUnitOfWork uow;
       
        public CompanyController()
        {
            uow = new EfUnitOfWork(new FindWorkersTezContext());
        }

       
         [HttpGet("")]
         public IActionResult GetCompany()
         {
             try
             {
                 var result = uow.Companies.GetAll()?.ToList();
                 if (result != null)
                     return Ok(result);
             }
             catch (Exception ex)
             {
                 return BadRequest(ex.Message);

             }
             return BadRequest("Error");
         }
        [Route("GetLoginUser")]
        [HttpGet]
        public IActionResult GetLoginUser()
        {
            var email = User.Claims.FirstOrDefault().Value;
            return Ok(uow.Companies.Find(x => x.CompanyEmail == email).FirstOrDefault());
        }
        

        /*[HttpPost("")]
        public IActionResult AddCompany(Company entity)
        {
           var result = Request.Headers["RoleId"];

            var rol = uow.Roles.Get(Convert.ToInt32(result));
            entity.role = rol;
            uow.Companies.Post(entity);
            uow.SaveChanges();
            return Ok("ok");
        }*/



        [HttpPut("")]
         public IActionResult UpdateCompany([FromBody] Company entity)
         {
             entity.role = uow.Roles.Get(entity.RoleId);
             uow.Companies.Put(entity);
             uow.SaveChanges();
             return Ok("ok");

         }

         [HttpGet("Delete")]
         public IActionResult RemoveCompany()
         {
            var id = Request.Headers["Id"];
            var company = uow.Companies.Get(Convert.ToInt32(id));
             //entity.role = uow.Roles.Get(entity.RoleId);
             uow.Companies.Delete(company);
             uow.SaveChanges();
             return Ok("ok");
         }

        /*[HttpPost]
        [Route("login")]
        public IActionResult CompanyLogin([FromBody]Company entity)
        {
            try
            {
                var result = uow.Companies.Find(i => i.Password == entity.Password && i.CompanyEmail == entity.CompanyEmail).FirstOrDefault();
                if (result != null)
                    return Ok("ok");
                else
                    return BadRequest("error");
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }*/
        /*[HttpGet("Delete")]
        public bool RemoveCompany(int id)
        {
            uow.Companies.Delete(uow.Companies.Get(id));
            uow.SaveChanges();
            return true;
        }*/

        /*[HttpPost("Delete")]
       public RedirectToActionResult DeleteCompany(int Id)
       {
           if (Id != 0)
           {
               var entity = uow.Companies.Get(Id);
               uow.Companies.Delete(entity);
               uow.SaveChanges();
               return RedirectToAction("CompanyList");
           }

           return RedirectToAction("CompanyList");
       }*/

        [HttpGet("GetCV")]
        public IActionResult GetCV()
        {

            CvList cvList1 = new CvList();
            

            try
            {

                ////cv.Contact = uow.Contacts.GetAll().ToList();
                //cv.CvData = uow.CvDatas.GetAll().ToList();
                ////cv.Document = uow.Documents.GetAll().ToList();
                //cv.Education = uow.Educations.GetAll().ToList();
                ////cv.Hobby = uow.Hobbies.GetAll().ToList();
                ////cv.Language = uow.Languages.GetAll().ToList();
                ////cv.Location = uow.Locations.GetAll().ToList();
                ////cv.Project = uow.Projects.GetAll().ToList();
                ////cv.Reference = uow.References.GetAll().ToList();
                //cv.Skill = uow.Skills.GetAll().ToList();
                ////cv.WorkExperience = uow.WorkExperiences.ToList();
                List<Cvdata> cvList = uow.CvDatas.GetAll().ToList();

                CvList cvViewLists = new CvList();
                List<CvViewList> lst = new List<CvViewList>();
                foreach (var item in cvList)
                {
                    string skillName = "",departmentName="";
                    List<Skill> skillsList = uow.Skills.Find(i => i.UserId == item.UserId).ToList();
                    foreach (var itemSkill in skillsList)
                    {
                        skillName += itemSkill.SkillName;
                    }
                    List<Education> educationList = uow.Educations.Find(i => i.UserId == item.UserId).ToList();
                    foreach (var itemEducation in educationList)
                    {
                        departmentName += itemEducation.Department;
                    }
                    CvViewList cvView = new CvViewList();
                    cvView.CvName = item.CvName;
                    cvView.Department = departmentName;
                    cvView.Skills = skillName;
                    lst.Add(cvView);
                }

                cvViewLists.cvViewLists = lst;
                return Ok(cvViewLists);

            }


            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}