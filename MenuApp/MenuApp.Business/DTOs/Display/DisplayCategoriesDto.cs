using MenuApp.Business.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuApp.Business.DTOs.Display
{
    public class DisplayCategoriesDto
    {
        public Guid Id { get; set; }
        public string MenuName { get; set; }
        public string BackgroundImage { get; set; }
        public string TextColor { get; set; }
        public string ButtonColor { get; set; }
        public List<CategoryListDto> Categories { get; set; }
    }
}
