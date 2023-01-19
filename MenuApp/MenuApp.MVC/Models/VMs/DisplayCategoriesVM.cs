using MenuApp.Business.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.MVC.Models.VMs
{
    public class DisplayCategoriesVM
    {
        public Guid Id { get; set; }
        public string MenuName { get; set; }
        public string BackgroundImage { get; set; }
        public string TextColor { get; set; }
        public string ButtonColor { get; set; }
        public List<CategoryListDto> Categories { get; set; }
    }
}
