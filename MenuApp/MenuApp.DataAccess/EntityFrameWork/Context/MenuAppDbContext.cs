using MenuApp.Core.Entities.Abstracts;
using MenuApp.Core.Enums;
using MenuApp.Entity.Concretes;
using MenuApp.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MenuApp.DataAccess.EntityFrameWork.Context
{
    public class MenuAppDbContext : IdentityDbContext
    {     
        private readonly IHttpContextAccessor _contextAccessor;
        public MenuAppDbContext()
        {

        }
        public MenuAppDbContext(DbContextOptions<MenuAppDbContext> options, IHttpContextAccessor contextAccessor) : base(options)
        {
            _contextAccessor = contextAccessor;
        }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(IMapper).Assembly);

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            SetBaseProperties();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetBaseProperties();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetBaseProperties()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            foreach (var entry in entries)
            {
                SetIfAdded(entry);
                SetIfModified(entry);
                SetIfDeleted(entry);
            }
        }

        private void SetIfAdded(EntityEntry<BaseEntity> entityEntry)
        {
            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Entity.Status = Status.Active;
                entityEntry.Entity.CreatedDate = DateTime.Now;
                entityEntry.Entity.CreatedBy = _contextAccessor.HttpContext?.User.Identity.Name ?? "Non-User";
            }
        }

        private void SetIfModified(EntityEntry<BaseEntity> entityEntry)
        {
            if (entityEntry.State == EntityState.Modified)
            {
                entityEntry.Entity.Status = Status.Modified;
            }
            entityEntry.Entity.ModifiedDate = DateTime.Now;
            entityEntry.Entity.ModifiedBy = _contextAccessor.HttpContext?.User.Identity.Name ?? "Non-User";
        }

        private void SetIfDeleted(EntityEntry<BaseEntity> entityEntry)
        {
            if (entityEntry.State != EntityState.Deleted)
            {
                return;
            }

            if (entityEntry.Entity is AuditableEntity)
            {
                entityEntry.State = EntityState.Modified;
                entityEntry.Entity.Status = Status.Passive;
                (entityEntry.Entity as AuditableEntity).DeletedDate = DateTime.Now;
                (entityEntry.Entity as AuditableEntity).DeletedBy = _contextAccessor.HttpContext.User.Identity.Name;
            }
        }
    }
}
