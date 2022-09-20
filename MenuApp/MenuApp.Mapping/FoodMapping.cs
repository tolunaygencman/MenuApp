using MenuApp.Core.Entities.Mapping;
using MenuApp.Entity.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuApp.Mapping
{
    public class FoodMapping : AuditableEntityMapping<Food>
    {
        public override void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Image).IsRequired();
            builder.HasOne(x => x.Category).WithMany(x => x.Foods).HasForeignKey(x => x.CategoryId);
            base.Configure(builder);
        }
    }
}
