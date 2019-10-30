using System;
using System.Collections.Generic;

namespace FindWorker.Entity.Models
{
    public partial class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string Password { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUser { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? LastModifiedUser { get; set; }

        public List<Advert> Adverts { get; set; }

        public int RoleId { get; set; }
        public Role role { get; set; }
    }
}
