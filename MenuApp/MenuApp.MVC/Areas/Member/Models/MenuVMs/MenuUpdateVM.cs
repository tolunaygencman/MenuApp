using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.MVC.Areas.Member.Models.MenuVMs
{
    public class MenuUpdateVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string TextColor { get; set; }
        public string ButtonColor { get; set; }
        public IFormFile BackgroundImage { get; set; }
    }
}
