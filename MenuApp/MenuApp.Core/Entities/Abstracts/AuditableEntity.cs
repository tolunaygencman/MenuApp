using MenuApp.Core.Entities.Interfaces;
using System;

namespace MenuApp.Core.Entities.Abstracts
{
    public abstract class AuditableEntity : BaseEntity, IDeleteableEntity
    {
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
