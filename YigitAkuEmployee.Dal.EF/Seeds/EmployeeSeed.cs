using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
                    FirstName="Altug",
                    LastName="Aytimur",
                    Email="altugaytimur@hotmail.com",
                    DateOfBirth=new DateTime(1990,09,11),
                    Department="Bilgi Teknolojileri",
                    PhoneNumber="05321707878",
                    CreatedBy = "System",
                    CreatedDate = DateTime.UtcNow,
                    ModifiedBy = "System",
                    ModifiedDate = DateTime.UtcNow,
                    Status = Core.Enums.Status.Added
                },
                new Employee
                {

                    FirstName="Bilal",
                    LastName="Arslan",
                    Email="bilalarslan@hotmail.com",
                    DateOfBirth=new DateTime(1992,09,11),
                    Department="Bilgi Teknolojileri",
                    PhoneNumber="05059639509",
                    CreatedBy = "System",
                    CreatedDate = DateTime.UtcNow,
                    ModifiedBy = "System",
                    ModifiedDate = DateTime.UtcNow,
                    Status = Core.Enums.Status.Added
                },
                new Employee
                {

                    FirstName="Elif",
                    LastName="Kaymak",
                    Email="elifkaymak@hotmail.com",
                    DateOfBirth=new DateTime(1993,09,11),
                    Department="Bilgi Teknolojileri",
                    PhoneNumber="05321707777",
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
}
