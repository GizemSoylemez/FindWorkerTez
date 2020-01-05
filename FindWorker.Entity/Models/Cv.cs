using System;
using System.Collections.Generic;
using System.Text;

namespace FindWorker.Entity.Models
{
    public class Cv
    {

        public List<Education> Education { get; set; }
        public List<Project> Project { get; set; }
        public List<Skill> Skill { get; set; }
        public List<Document> Document { get; set; }
        public List<Reference> Reference { get; set; }
        public List<Language> Language { get; set; }
        public List<Contact> Contact { get; set; }
        public List<Hobby> Hobby { get; set; }
        public List<Location> Location { get; set; }
        public List<WorkExperience> WorkExperience { get; set; }
        public List<Cvdata> CvData { get; set; }
    }
}
