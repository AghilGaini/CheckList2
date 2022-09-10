using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheckList2.SignalR
{
    public class SignalRTest : Hub
    {
        public static long clientsNumber = 0;

        public override async Task OnConnectedAsync()
        {
            clientsNumber++;
            if (clientsNumber % 2 == 0)
                await Groups.AddToGroupAsync(Context.ConnectionId, "Even");
            else
                await Groups.AddToGroupAsync(Context.ConnectionId, "Odd");

        }

        public async Task SendTestMessage(string msg)
        {
            try
            {
                await Clients.All.SendAsync("RecieveRequestTest", msg);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
    }
}
