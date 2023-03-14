using Microsoft.AspNet.SignalR;
using Owin;
using TestApp.MVC.Hubs;

namespace TestApp.MVC
{
    public class Startup
    {
        public void Configuration(IAppBuilder app) 
        {
            string sqlConnectionString = "Cadena de conexion a la bbdd";
            GlobalHost.DependencyResolver.UseSqlServer(sqlConnectionString);
            app.MapSignalR();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR()
                    .AddAzureSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseFileServer();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chat");
            });
        }
    }
}
