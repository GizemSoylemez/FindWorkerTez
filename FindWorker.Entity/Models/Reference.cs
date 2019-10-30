using System;
using System.Collections.Generic;

namespace FindWorker.Entity.Models
{
    public partial class Reference
    {
        public int Id { get; set; }
        public string ReferenceName { get; set; }
        public string ReferencePosition { get; set; }
        public string ReferencePhone { get; set; }
        public string ReferenceEmail { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUser { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? LastModifiedUser { get; set; }


        public int? UserId { get; set; }
        public User user { get; set; }
    }
}
