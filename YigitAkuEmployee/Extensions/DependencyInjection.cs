using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;

namespace YigitAkuEmployee.MVC.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMvcServices(this IServiceCollection services)
        {
            services
            .AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

            services
           .AddFluentValidationAutoValidation()
           .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services
            .AddHttpContextAccessor()
            .AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddSession();
            return services;
        }
    }
}
