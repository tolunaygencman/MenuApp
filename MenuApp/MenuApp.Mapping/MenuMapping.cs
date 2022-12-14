using MenuApp.Core.Entities.Mapping;
using MenuApp.Entity.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuApp.Mapping
{
    public class MenuMapping : AuditableEntityMapping<Menu>
    {
        public override void Configure(EntityTypeBuilder<Menu> builder)
        {
            base.Configure(builder);
            builder.HasOne(x => x.Member).WithMany(x => x.Menus).HasForeignKey(x => x.UserId);
            builder.Property(x => x.BackgroundImage).IsRequired();
            builder.Property(x => x.TextColor).IsRequired();
            builder.Property(x => x.ButtonColor).IsRequired();
        }
    }
}
