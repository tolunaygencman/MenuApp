using MenuApp.Core.Enums;
using System;

namespace MenuApp.Core.Entities.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }
        Status Status { get; set; }
    }
}
