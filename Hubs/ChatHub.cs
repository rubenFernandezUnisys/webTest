using Microsoft.AspNetCore.SignalR;

namespace TestApp.MVC.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string room, string fromUser, string message) 
        {
            await Clients.Group(room).SendAsync("ReceiveMessage", fromUser, message);
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
        public Task Echo(string name, string message) =>
            Clients.Client(Context.ConnectionId)
                   .SendAsync("echo", name, $"{message} (echo from server)");

        public async Task AddToGroup(string room)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, room);
            await Clients.Group(room).SendAsync("ShowWho", $"Alguien se ha conectado{Context.ConnectionId}");
        }
    }
}
