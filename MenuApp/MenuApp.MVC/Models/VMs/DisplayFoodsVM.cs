using MenuApp.Business.DTOs.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.MVC.Models.VMs
{
    public class DisplayFoodsVM
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string BackgroundImage { get; set; }
        public string TextColor { get; set; }
        public string ButtonColor { get; set; }
        public List<FoodListDto> Foods { get; set; }
    }
}
