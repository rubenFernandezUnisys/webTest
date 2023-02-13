using Auth0.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using TestApp.MVC.Data;
using TestApp.MVC.Hubs;



var builder = WebApplication.CreateBuilder(args);

var conn = builder.Configuration.GetConnectionString("ManagementDbConnection");
builder.Services.AddDbContext<ManagementDbContext>(q => q.UseSqlServer(conn));
// Add services to the container.
builder.Services
        .AddAuth0WebAppAuthentication(options => {
            options.Domain = builder.Configuration["Auth0:Domain"];
            options.ClientId = builder.Configuration["Auth0:ClientId"];
        });
builder.Services.AddSignalR();

builder.Services.AddControllersWithViews();

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

app.UseAuthentication();
app.UseAuthorization();
app.MapHub<ChatHub>("/chatHub");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
