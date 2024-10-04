using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); // add MVC servises
builder.Services.AddDbContext<WebAPI.Data.NorthwindContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindDatabase")));
//sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()));

var app = builder.Build();

// Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


