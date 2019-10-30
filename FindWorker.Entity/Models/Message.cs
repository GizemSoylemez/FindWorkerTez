using System;
using System.Collections.Generic;

namespace FindWorker.Entity.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public string Message1 { get; set; }
        public int? SendById { get; set; }
        public int? ReceiveById { get; set; }
        public DateTime? MessageDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUser { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? LastModifiedUser { get; set; }

        public int CompanyId { get; set; }
        public Company company { get; set; }
    }
}
