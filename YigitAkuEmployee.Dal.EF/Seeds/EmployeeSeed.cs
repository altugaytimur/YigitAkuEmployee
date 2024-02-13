using Castle.Core.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YigitAkuEmployee.Dal.Contexts;
using YigitAkuEmployee.Entities.DbSets;

namespace YigitAkuEmployee.Dal.EF.Seeds
{
    internal static class EmployeeSeed
    {
        public static async Task SeedAsync(IConfiguration configuration)
        {
            var dbContextBuilder = new DbContextOptionsBuilder<YigitAkuDbContext>();

            dbContextBuilder.UseSqlServer(configuration.GetConnectionString("sqlconnection"));

            using YigitAkuDbContext context = new(dbContextBuilder.Options);

            if (!context.Employees.Any())
            {
                var employees = new Employee[]
                {
                new Employee
                {
                 
                    CreatedBy = "System",
                    CreatedDate = DateTime.UtcNow,
                    ModifiedBy = "System",
                    ModifiedDate = DateTime.UtcNow,
                    Status = Core.Enums.Status.Added
                },
                new Employee
                {
                   
                    CreatedBy = "System",
                    CreatedDate = DateTime.UtcNow,
                    ModifiedBy = "System",
                    ModifiedDate = DateTime.UtcNow,
                    Status = Core.Enums.Status.Added
                },
                new Employee
                {
                   
                    CreatedBy = "System",
                    CreatedDate = DateTime.UtcNow,
                    ModifiedBy = "System",
                    ModifiedDate = DateTime.UtcNow,
                    Status = Core.Enums.Status.Added
                },

                };

                await context.Employees.AddRangeAsync(employees);
                await context.SaveChangesAsync();
            }
    }
}
