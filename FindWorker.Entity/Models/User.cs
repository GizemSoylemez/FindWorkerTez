using System;
using System.Collections.Generic;

namespace FindWorker.Entity.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ProfilePhoto { get; set; }
        public bool? MilitaryStatus { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUser { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? LastModifiedUser { get; set; }

        public List<Contact> Contacts { get; set; }
        public List<Document> Documents { get; set; }
        public List<Education> Educations { get; set; }
        public List<Hobby> Hobbies { get; set; }
        public List<Language> Languages { get; set; }
        public List<Project> Projects { get; set; }
        public List<Reference> References { get; set; }
        public List<Skill> Skills { get; set; }
        public List<WorkExperience> WorkExperiences { get; set; }
        public List<Location> Location { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
