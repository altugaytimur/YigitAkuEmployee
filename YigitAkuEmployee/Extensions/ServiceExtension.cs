using Microsoft.EntityFrameworkCore;
using YigitAkuEmployee.Dal.Contexts;

namespace YigitAkuEmployee.MVC.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) => services.AddDbContext<YigitAkuDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("sqlconnection")));
    }
}
