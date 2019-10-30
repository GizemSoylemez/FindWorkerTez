using System;
using System.Collections.Generic;

namespace FindWorker.Entity.Models
{
    public partial class Hobby
    {
        public int Id { get; set; }
        public string HobbiesName { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUser { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string LastModifiedUser { get; set; }


        public int? UserId { get; set; }
        public User user { get; set; }
    }
}
