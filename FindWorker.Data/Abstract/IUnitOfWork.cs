using FindWorker.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FindWorker.Data.Abstract
{
    public interface IUnitOfWork
    {
        ICompanyRepository Companies { get; }
        IUserRepository Users { get; }
        IAdvertRepository Adverts { get; }
        IContactRepository Contacts { get; }
        ICvDataRepository CvDatas { get; }
        IDocumentRepository Documents { get; }
        IEducationRepository Educations { get; }
        IHobbyRepository Hobbies { get; }
        ILanguageRepository Languages { get; }
        ILocationRepository Locations { get; }
        IMessageRepository Messages { get; }
        IProjectRepository Projects { get; }
        IReferenceRepository References { get; }
        IRoleRepository Roles { get; }
        ISkillRepository Skills { get; }
        IWorkExperienceRepository WorkExperiences { get; }

        bool SaveChanges();
    }
}
