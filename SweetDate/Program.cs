using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SweetDate;
using SweetDate.DAL;
using SweetDate.DAL.Interfaces;
using SweetDate.DAL.Repositories;
using SweetDate.Service.Implementations;
using SweetDate.Service.Interfaces;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connection));



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Profil/Login");
        options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Profil/Login");
    });



builder.Services.AddRazorPages();
builder.Services.InitializeRepositories();
builder.Services.InitializeServices();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console() // Вывод логов в консоль
    .CreateLogger();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// app.MapControllerRoute(
//     name: "LatestUsers",
//     pattern: "latest-users",
//     defaults: new { controller = "Person", action = "GetLatestUsers" }
// );

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages(); // Подключение маршрутизации для Razor Pages

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

});

app.Run();

