using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using YigitAkuEmployee.Dal.Contexts;

namespace YigitAkuEmployee.MVC.ContextFactory
{
    public class YigitAkuDbContextFactory : IDesignTimeDbContextFactory<YigitAkuDbContext>
    {
        public YigitAkuDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            var builder = new DbContextOptionsBuilder<YigitAkuDbContext>().UseSqlServer(configuration.GetConnectionString("sqlconnection"), prj => prj.MigrationsAssembly("YigitAkuEmployee.Dal"));

            return new YigitAkuDbContext(builder.Options);
        }

    }
}
