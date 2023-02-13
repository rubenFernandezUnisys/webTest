using Auth0.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using TestApp.MVC.Data;
//Agregamos la carpeta de Hubs
using TestApp.MVC.Hubs;



var builder = WebApplication.CreateBuilder(args);

var conn = builder.Configuration.GetConnectionString("ManagementDbConnection");
builder.Services.AddDbContext<ManagementDbContext>(q => q.UseSqlServer(conn));
// Agregar los servicios al contenedor
builder.Services
        .AddAuth0WebAppAuthentication(options => {
            options.Domain = builder.Configuration["Auth0:Domain"];
            options.ClientId = builder.Configuration["Auth0:ClientId"];
        });
//Agregamos los servicios de SignalR
builder.Services.AddSignalR();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar la petición HTTP del pipeline
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
//Se agrega el maphub
app.MapHub<ChatHub>("/chatHub");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
