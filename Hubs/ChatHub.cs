using Microsoft.AspNetCore.SignalR;

namespace TestApp.MVC.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string room, string fromUser, string message) 
        {
            await Clients.Group(room).SendAsync("ReceiveMessage", fromUser, message);
        }

        public async Task AddToGroup(string room)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, room);
            await Clients.Group(room).SendAsync("ShowWho", $"Alguien se ha conectado{Context.ConnectionId}");
        }
    }
}
