using MenuApp.Core.Entities.Abstracts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MenuApp.Core.Entities.Mapping
{
    public abstract class BaseUserMapping<T> : AuditableEntityMapping<T> where T : BaseUser
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(256).IsRequired();
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Email).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Address).IsRequired(false).HasMaxLength(512);
            builder.Property(x => x.Image).IsRequired(false);
            builder.Property(x => x.IdentityId).IsRequired();

            base.Configure(builder);
        }
    }
}
