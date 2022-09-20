using MenuApp.Core.Entities.Mapping;
using MenuApp.Entity.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MenuApp.Mapping
{
    public class AdminMapping : BaseUserMapping<Admin>
    {
        public override void Configure(EntityTypeBuilder<Admin> builder)
        {
            base.Configure(builder);
        }
    }
}
