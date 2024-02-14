using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
            builder.Property(m => m.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DateOfBirth).IsRequired();
            builder.Property(x=>x.Department).IsRequired().HasMaxLength(50);
            builder.Property(x => x.PhoneNumber).HasMaxLength(11);
            
        }
    }
    
}
