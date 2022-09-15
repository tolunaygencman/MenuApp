using MenuApp.Core.Entities.Interfaces;
using MenuApp.Core.Enums;
using System;

namespace MenuApp.Core.Entities.Abstracts
{
    public abstract class BaseEntity : ICreateableEntity
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
