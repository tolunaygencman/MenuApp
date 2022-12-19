﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MenuApp.Business.DTOs.Categories
{
    public class CategoryCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Guid MenuId { get; set; }
    }
}
