using MenuApp.Core.Entities.Interfaces;
using System;

namespace MenuApp.Core.Entities.Abstracts
{
    public abstract class BaseUser : AuditableEntity, IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public string IdentityId { get; set; }
    }
}
