using System;
using System.Collections.Generic;
using System.Text;

namespace MenuApp.Business.DTOs.Categories
{
    public class CategoryUpdateWithoutImgDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
