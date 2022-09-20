using MenuApp.Core.Entities.Mapping;
using MenuApp.Entity.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MenuApp.Mapping
{
    public class CategoryMapping : AuditableEntityMapping<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Image).IsRequired();
            builder.HasOne(x => x.Menu).WithMany(x => x.Categories).HasForeignKey(x => x.MenuId);
            base.Configure(builder);
        }

    }
}
