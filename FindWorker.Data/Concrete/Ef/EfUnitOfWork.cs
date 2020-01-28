using FindWorker.Data.Abstract;
using FindWorker.Data.Concrete.Ef;
using FindWorker.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FindWorker.Data.Concrete.Ef
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly FindWorkersTezContext dbContext;

        public EfUnitOfWork(FindWorkersTezContext _dbcontext)
        {
            dbContext = _dbcontext ?? throw new ArgumentNullException("Db context can't be null");
        }

        private ICompanyRepository _company;
        private IContactRepository _contact;
        private ICvDataRepository _cv;
        private IDocumentRepository _document;
        private IEducationRepository _education;
        private IHobbyRepository _hobby;
        private ILanguageRepository _language;
        private ILocationRepository _location;
        private IProjectRepository _project;
        private IReferenceRepository _reference;
        private IRoleRepository _role;
        private ISkillRepository _skill;
        private IWorkExperienceRepository _workexperience;
        private IUserRepository _user;

        public ICompanyRepository Companies
        {
            get
            {
                return _company ?? (_company = new EfCompanyRepository(dbContext));
            }
        }

        public IUserRepository Users
        {
            get
            {
                return _user ?? (_user = new EfUserRepository(dbContext));
            }
        }

       
        public IContactRepository Contacts
        {
            get
            {
                return _contact ?? (_contact = new EfContactRepository(dbContext));
            }
        }

        public ICvDataRepository CvDatas
        {
            get
            {
                return _cv ?? (_cv = new EfCvdataRepository(dbContext));
            }
        }

        public IDocumentRepository Documents
        {
            get
            {
                return _document ?? (_document = new EfDocumentRepository(dbContext));
            }
        }

        public IEducationRepository Educations
        {
            get
            {
                return _education ?? (_education = new EfEducationRepository(dbContext));
            }
        }

        public IHobbyRepository Hobbies
        {
            get
            {
                return _hobby ?? (_hobby = new EfHobbyRepository(dbContext));
            }
        }

        public ILanguageRepository Languages
        {
            get
            {
                return _language ?? (_language = new EfLanguageRepository(dbContext));
            }
        }

        public ILocationRepository Locations
        {
            get
            {
                return _location ?? (_location = new EfLocationRepository(dbContext));
            }
        }

       
        public IProjectRepository Projects
        {
            get
            {
                return _project ?? (_project = new EfProjectRepository(dbContext));
            }
        }

        public IReferenceRepository References
        {
            get
            {
                return _reference ?? (_reference = new EfReferenceRepository(dbContext));
            }
        }

        public IRoleRepository Roles
        {
            get
            {
                return _role ?? (_role = new EfRoleRepository(dbContext));
            }
        }

        public ISkillRepository Skills
        {
            get
            {
                return _skill ?? (_skill = new EfSkillRepository(dbContext));
            }
        }

        public IWorkExperienceRepository WorkExperiences
        {
            get
            {
                return _workexperience ?? (_workexperience = new EfWorkExperienceRepository(dbContext));
            }
        }

        public bool SaveChanges()
        {
            try 
            {
                dbContext.SaveChanges(); 
                return true;
            }
            catch (Exception e) 
            {
                return false; 
            }
        }
    }
}
