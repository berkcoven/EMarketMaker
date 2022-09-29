using EMarketMaker.MVCUser.Data;
using EMartketMaker.MVCUser;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var servVersion = new MariaDbServerVersion(new Version(5, 7, 39));
var conString = "server=185.26.144.175;uid=oyntch_unzJaPm;pwd=KiD*dV5d;database=oyntch_nONf6RN";
builder.Services.AddDbContext<oyntch_nONf6RNContext>(options => options.UseMySql(conString, servVersion));

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
