using Microsoft.EntityFrameworkCore;
using YigitAkuEmployee.Dal.Contexts;

namespace YigitAkuEmployee.WebApi.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
        IConfiguration configuration) =>
        services.AddDbContext<YigitAkuDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("sqlconnection")));
    }
}
