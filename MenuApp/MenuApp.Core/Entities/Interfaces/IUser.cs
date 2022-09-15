using System;

namespace MenuApp.Core.Entities.Interfaces
{
    public interface IUser
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string IdentificationNumber { get; set; }
        string Address { get; set; }
        DateTime DateOfBirth { get; set; }
        bool Gender { get; set; }
        string Image { get; set; }
        string IdentityId { get; set; }
    }
}
