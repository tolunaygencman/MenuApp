using System;
using System.Collections.Generic;
using System.Text;

namespace MenuApp.Business.DTOs.Foods
{
    public class FoodUpdateWithoutImgDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
