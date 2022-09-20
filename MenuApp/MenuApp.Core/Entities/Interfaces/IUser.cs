using System;

namespace MenuApp.Core.Entities.Interfaces
{
    public interface IUser
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Address { get; set; }
        string Image { get; set; }
        string IdentityId { get; set; }
    }
}
