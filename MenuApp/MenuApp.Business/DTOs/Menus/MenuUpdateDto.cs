using System;
using System.Collections.Generic;
using System.Text;

namespace MenuApp.Business.DTOs.Menus
{
    public class MenuUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string BackgroundImage { get; set; }
        public string TextColor { get; set; }
        public string ButtonColor { get; set; }
    }
}
