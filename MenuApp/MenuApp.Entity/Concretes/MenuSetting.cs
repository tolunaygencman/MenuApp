using MenuApp.Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuApp.Entity.Concretes
{
    public class MenuSetting : AuditableEntity
    {
        public string BackgroundImage { get; set; }
        public string TextColor { get; set; }
        public string ButtonColor { get; set; }
        //nav props
        public Guid MenuId { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
