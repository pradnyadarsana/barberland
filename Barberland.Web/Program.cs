using Barberland.Data;
using Barberland.Data.Entity;
using Barberland.Data.Repository;
using Barberland.Service;
using Barberland.Utility;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var Configuration = builder.Configuration;
builder.Services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

builder.Services.AddDbContext<DataContext>(options =>
        options.UseNpgsql(
            Configuration.GetConnectionString("DefaultConnection"),
            x =>
            {
                x.MigrationsHistoryTable("ef_migration_history");
                x.MigrationsAssembly(typeof(Program).Assembly.FullName);
            }
        ).UseSnakeCaseNamingConvention());

//builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IServiceCategoryRepository, ServiceCategoryRepository>();
builder.Services.AddScoped<IServiceCategoryImageRepository, ServiceCategoryImageRepository>();
builder.Services.AddScoped<IBarbershopRepository, BarbershopRepository>();

builder.Services.AddTransient<IHomePageService, HomePageService>();
builder.Services.AddTransient<IBarbershopService, BarbershopService>();
builder.Services.AddTransient<IServiceCategoryService, ServiceCategoryService>();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseStatusCodePagesWithReExecute("/Error/Index/{0}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "barbershop-profile",
    pattern: "{barbershopPermalink}",
    defaults: new { controller = "Barbershop", action = "Detail" });

app.MapControllerRoute(
    name: "service-category-detail",
    pattern: "{barbershopPermalink}/{serviceCategoryPermalink}",
    defaults: new { controller = "ServiceCategory", action = "Detail" });

app.Run();

