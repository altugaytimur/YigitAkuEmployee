using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using YigitAkuEmployee.Dal.Contexts;

namespace YigitAkuEmployee.WebApi.ContextFactory
{
    public class YigitAkuDbContextFactory : IDesignTimeDbContextFactory<YigitAkuDbContext>
    {
        public YigitAkuDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            var builder = new DbContextOptionsBuilder<YigitAkuDbContext>()
                .UseSqlServer(configuration.GetConnectionString("YigitAkuDbConnection"), prj => prj.MigrationsAssembly("YigitAkuEmployee.Dal"));
            return new YigitAkuDbContext(builder.Options);
        }
    }
}
