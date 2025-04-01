using Microsoft.AspNetCore.SignalR;

namespace StudentCenterApi.src.Infrastructure.Util;

public class StatusHub : Hub
{
    public async Task SendIdAndDescription(string id, string description)
    {
        await Clients.All.SendAsync("ReceiveIdAndDescription", id, description);
    }
}
