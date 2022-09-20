using MenuApp.Core.Entities.Mapping;
using MenuApp.Entity.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuApp.Mapping
{
    public class MemberMapping : BaseUserMapping<Member>
    {
        public override void Configure(EntityTypeBuilder<Member> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.RestourantName).HasMaxLength(256).IsRequired();
            builder.HasMany(x => x.Menus);
        }
    }
}
