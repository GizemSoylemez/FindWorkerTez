using System;
using System.Collections.Generic;

namespace FindWorker.Entity.Models
{
    public partial class Document
    {
        public int Id { get; set; }
        public string DocumentationName { get; set; }
        public int DocumentDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUser { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? LastModifiedUser { get; set; }


        public int? UserId { get; set; }
        public User user { get; set; }
    }
}
