using System;
using System.Collections.Generic;

namespace FindWorker.Entity.Models
{
    public partial class Skill
    {
        public int Id { get; set; }
        public string SkillName { get; set; }
        public string SkillLevel { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreaitonUser { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? LastModifiedUser { get; set; }


        public int? UserId { get; set; }
        public User user { get; set; }
    }
}
