using System;
using System.Collections.Generic;

namespace FindWorker.Entity.Models
{
    public partial class Advert
    {
        public int Id { get; set; }
        public string AdvertName { get; set; }
        public string Position { get; set; }
        public string SchoolType { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUser { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? LastModifiedUser { get; set; }

        public int CompanyId { get; set; }
        public Company company { get; set; }
    }
}
