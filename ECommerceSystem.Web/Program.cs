using Serilog;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using ECommerceSystem.Core.Interfaces;
using ECommerceSystem.Infrastructure.Repositories;

//serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllersWithViews();

//DbContext register
builder.Services.AddDbContext<ECommerceDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("ECommerceDB"),
        new MySqlServerVersion(new Version(8, 0, 41))));


//autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(container =>
{
    container.RegisterType<UnitOfWork>()
             .As<IUnitOfWork>()
             .InstancePerLifetimeScope();

    container.RegisterType<ProductRepository>()
             .As<IProductRepository>()
             .InstancePerLifetimeScope();
});

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
