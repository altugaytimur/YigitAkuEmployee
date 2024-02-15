using YigitAkuEmployee.Business.Extensions;
using YigitAkuEmployee.Dal.EF.Extensions;
using YigitAkuEmployee.MVC.Extensions;
using YigitAkuEmployee.MVC.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllersWithViews();
builder.Services
    .AddEFCoreServices(builder.Configuration)
    .AddBusinessServices();
builder.Services
    .ConfigureSqlContext(builder.Configuration);
builder.Services
    .AddMvcServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
