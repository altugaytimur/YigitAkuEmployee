using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YigitAkuEmployee.Core.Entities.Base;

namespace YigitAkuEmployee.Core.Entities.EntityTypeConfigurations
{
    public  class AuditableEntityConfiguration<T>:BaseEntityConfiguration<T> where T:AuditableEntity
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.DeletedDate).IsRequired(false);
            builder.Property(x => x.DeletedBy).HasMaxLength(128).IsRequired(false);
        }
    }
}
