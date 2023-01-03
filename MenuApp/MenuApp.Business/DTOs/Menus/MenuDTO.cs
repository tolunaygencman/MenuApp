using System;
using System.Collections.Generic;
using System.Text;

namespace MenuApp.Business.DTOs.Menus
{
   public class MenuDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public string BackgroundImage { get; set; }
        public string TextColor { get; set; }
        public string ButtonColor { get; set; }
    }
}

