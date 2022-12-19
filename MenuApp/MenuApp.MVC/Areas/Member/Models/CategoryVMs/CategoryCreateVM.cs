using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.MVC.Areas.Member.Models.CategoryVMs
{
    public class CategoryCreateVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid MenuId { get; set; }
        public IFormFile Image { get; set; }
    }
}
