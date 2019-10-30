using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindWorker.Api.Models
{
    public class Login :IdentityUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
