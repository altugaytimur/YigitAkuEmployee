using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YigitAkuEmployee.Dal.EF.Repostories;
using YigitAkuEmployee.Dal.EF.Seeds;
using YigitAkuEmployee.Dal.İnt.Repostories;

namespace YigitAkuEmployee.Dal.EF.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEFCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            EmployeeSeed.SeedAsync(configuration).GetAwaiter().GetResult();

            return services;
        }
    }
}
