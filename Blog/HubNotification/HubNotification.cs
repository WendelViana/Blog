using Microsoft.AspNetCore.SignalR;

namespace Blog.HubNotification
{
    public class HubNotification: Hub
    {
        public HubNotification() { }

        public async Task SendNotification(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
