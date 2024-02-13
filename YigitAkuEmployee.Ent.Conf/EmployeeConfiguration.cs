using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YigitAkuEmployee.Core.Entities.EntityTypeConfigurations;
using YigitAkuEmployee.Entities.DbSets;

namespace YigitAkuEmployee.Ent.Conf
{
    public class EmployeeConfiguration:AuditableEntityConfiguration<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);

            builder.HasKey(e => e.Id);
            builder.Property(m => m.FirstName).IsRequired().HasMaxLength(256);
            
        }
    }
    
}
