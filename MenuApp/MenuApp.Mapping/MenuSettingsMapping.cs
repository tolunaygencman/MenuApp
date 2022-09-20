using MenuApp.Core.Entities.Mapping;
using MenuApp.Entity.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuApp.Mapping
{
    public class MenuSettingsMapping : AuditableEntityMapping<MenuSetting>
    {
        public override void Configure(EntityTypeBuilder<MenuSetting> builder)
        {
            builder.Property(x => x.BackgroundImage).IsRequired();
            builder.Property(x => x.TextColor).IsRequired();
            builder.Property(x => x.ButtonColor).IsRequired();
            base.Configure(builder);

        }
    }
}
