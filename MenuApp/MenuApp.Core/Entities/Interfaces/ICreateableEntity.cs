using System;

namespace MenuApp.Core.Entities.Interfaces
{
    public interface ICreateableEntity : IEntity
    {
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
