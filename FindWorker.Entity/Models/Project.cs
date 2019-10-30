using System;
using System.Collections.Generic;

namespace FindWorker.Entity.Models
{
    public partial class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreaitonUser { get; set; }
        public int? LastModifiedUser { get; set; }
        public DateTime? LastModifiedDate { get; set; }


        public int? UserId { get; set; }
        public User user { get; set; }
    }
}
