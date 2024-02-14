using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YigitAkuEmployee.Business.Interfaces.Services;
using YigitAkuEmployee.Business.Services;

namespace YigitAkuEmployee.Business.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}
