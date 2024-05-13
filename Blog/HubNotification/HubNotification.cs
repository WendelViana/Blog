using Microsoft.AspNetCore.SignalR;

namespace Blog.Hubs
{
    public interface IMessageHubClient
    {
        Task SendOffersToUser(List<string> message);
    }

    public class MessageHub : Hub<IMessageHubClient>
    {
        public async Task SendOffersToUser(List<string> message)
        {
            await Clients.All.SendOffersToUser(message);
        }
    }

    public sealed class HubNotification: Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("SendMessage", message);
        }
    }
}
