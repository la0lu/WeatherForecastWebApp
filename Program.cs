using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WeatherForecast.Data;
using WeatherForecast.Data.Entities;
using WeatherForecast.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddDbContext<MVCContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("default")));
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<MVCContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
