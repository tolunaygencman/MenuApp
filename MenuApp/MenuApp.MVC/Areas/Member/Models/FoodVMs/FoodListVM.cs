using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.MVC.Areas.Member.Models.FoodVMs
{
    public class FoodListVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}
