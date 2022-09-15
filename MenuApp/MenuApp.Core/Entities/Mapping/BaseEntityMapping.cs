﻿using MenuApp.Core.Entities.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
namespace MenuApp.Core.Entities.Mapping
{
    public abstract class BaseEntityMapping<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.CreatedBy).HasMaxLength(128).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.ModifiedBy).HasMaxLength(128).IsRequired();
        }
    }
}
