using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using YigitAkuEmployee.Core.Entities.Base;
using YigitAkuEmployee.Core.Enums;
using YigitAkuEmployee.Ent.Conf;
using YigitAkuEmployee.Entities.DbSets;

namespace YigitAkuEmployee.Dal.Contexts
{
    public class YigitAkuDbContext:DbContext
    {
        public const string ConnectionName = "YigitAkuDbConnection";

        private readonly IHttpContextAccessor? _contextAccessor;

        public YigitAkuDbContext(DbContextOptions<YigitAkuDbContext> options, IHttpContextAccessor contexAccessor) : base(options)
        {
            _contextAccessor = contexAccessor;
        }

        public YigitAkuDbContext(DbContextOptions<YigitAkuDbContext> options) : base(options) { }

        public virtual DbSet<Employee> Employees { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(IEntityConfiguration).Assembly);

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

            var userId = _contextAccessor?.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "NotFound-User";
            foreach (var entry in entries)
            {
                SetIfAdded(entry, userId);
                SetIfModified(entry, userId);
                SetIfDeleted(entry, userId);
            }
        }

        private void SetIfAdded(EntityEntry<BaseEntity> entityEntry, string userId)
        {
            if (entityEntry.State != EntityState.Added)
            {
                return;
            }

            entityEntry.Entity.Status = Status.Added;
            entityEntry.Entity.CreatedDate = DateTime.Now;
            entityEntry.Entity.CreatedBy = userId;
        }

        private void SetIfModified(EntityEntry<BaseEntity> entityEntry, string userId)
        {
            if (entityEntry.State == EntityState.Modified)
            {
                entityEntry.Entity.Status = Status.Modified;
            }
            entityEntry.Entity.ModifiedDate = DateTime.Now;
            entityEntry.Entity.ModifiedBy = userId;
        }

        private void SetIfDeleted(EntityEntry<BaseEntity> entityEntry, string userId)
        {
            if (entityEntry.State is not EntityState.Deleted)
            {
                return;
            }

            if (entityEntry.Entity is not AuditableEntity entity)
            {
                return;
            }

            entityEntry.State = EntityState.Modified;

            entity.Status = Status.Deleted;
            entity.DeletedBy = userId;
            entity.DeletedDate = DateTime.Now;
        }
    }
}
