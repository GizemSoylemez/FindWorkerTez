using System;
using System.Collections.Generic;

namespace FindWorker.Entity.Models
{
    public partial class Education
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public DateTime? GruadetDate { get; set; }
        public string SchoolType { get; set; }
        public string Department { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreaitonUser { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? LastModifiedUser { get; set; }


        public int? UserId { get; set; }
        public User user { get; set; }
    }
}
