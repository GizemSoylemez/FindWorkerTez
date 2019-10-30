using System;
using System.Collections.Generic;

namespace FindWorker.Entity.Models
{
    public partial class WorkExperience
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateTime? WorkedTime { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUser { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? LastModifiedUser { get; set; }


        public int? UserId { get; set; }
        public User user { get; set; }
    }
}
