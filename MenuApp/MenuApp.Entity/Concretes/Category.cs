using MenuApp.Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuApp.Entity.Concretes
{
    public class Category : AuditableEntity
    {
        public Category()
        {
            Foods = new HashSet<Food>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        //nav props
        public Guid MenuId { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual ICollection<Food> Foods { get; set; }
    }
}
