using Microsoft.AspNetCore.SignalR;

namespace TestApp.MVC.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string fromUser, string message) 
        {
            await Clients.All.SendAsync("ReceiveMessage", fromUser, message);
        }
    }
}
