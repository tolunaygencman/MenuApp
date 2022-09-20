using MenuApp.Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuApp.Entity.Concretes
{
    public class Menu : AuditableEntity
    {
        public Menu()
        {
            Categories = new HashSet<Category>();
        }
        //nav props
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public virtual Member Member { get; set; }
        public virtual MenuSetting MenuSetting { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
