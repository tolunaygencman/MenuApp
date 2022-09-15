using MenuApp.Core.Entities.Interfaces;
using System;

namespace MenuApp.Core.Entities.Abstracts
{
    public abstract class BaseUser : AuditableEntity, IUser
    {
        public abstract string FirstName { get; set; }
        public abstract string LastName { get; set; }
        public abstract string Email { get; set; }
        public abstract string IdentificationNumber { get; set; }
        public abstract string Address { get; set; }
        public abstract DateTime DateOfBirth { get; set; }
        public abstract bool Gender { get; set; }
        public abstract string Image { get; set; }
        public abstract string IdentityId { get; set; }
    }
}
