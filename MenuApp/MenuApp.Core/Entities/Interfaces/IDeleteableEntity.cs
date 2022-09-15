using System;

namespace MenuApp.Core.Entities.Interfaces
{
    interface IDeleteableEntity : IEntity, ICreateableEntity, IUpdateableEntity
    {
        string DeletedBy { get; set; }
        DateTime? DeletedDate { get; set; }
    }
}
