using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.MVC.Models.VMs
{
    public class RegisterVM
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Email { get; set; }
        public string RestourantName { get; set; } 
        #nullable enable
        public string? Address { get; set; }
        public IFormFile? Image { get; set; }
    }
}
