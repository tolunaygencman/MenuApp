using MenuApp.Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuApp.Entity.Concretes
{
    public class Food : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        
        //Nav Props
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
