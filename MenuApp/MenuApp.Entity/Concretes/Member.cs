using MenuApp.Core.Entities.Abstracts;
using System.Collections.Generic;

namespace MenuApp.Entity.Concretes
{
    public class Member : BaseUser
    {
        public Member()
        {
            Menus = new HashSet<Menu>();
        }
        public string RestourantName { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }

    }
}
