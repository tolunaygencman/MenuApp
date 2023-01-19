using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.MVC.Models.VMs
{
    public class ChangePasswordVM
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
    
}
