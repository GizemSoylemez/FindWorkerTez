using System;
using System.Collections.Generic;

namespace FindWorker.Entity.Models
{
    public partial class Role
    {
        public int RoleId { get; set; }
        public string RoleType { get; set; }

        public List<User> Users { get; set; }
        public List<Company> Companies { get; set; }
    }
}
