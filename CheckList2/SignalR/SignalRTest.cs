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
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "Even");
                await SendTestMessageToEvenGroup();
            }
            else
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "Odd");
                await SendTestMessageToOddGroup();
            }
        }

        public async Task SendTestMessage(string msg)
        {
            try
            {
                await Clients.All.SendAsync("RecieveRequestTest", msg);
            }
            catch (System.Exception ex)
            {
                await Clients.Caller.SendAsync("Notification", ex.Message);
            }
        }

        public async Task SendTestMessageToOddGroup()
        {
            try
            {
                string msg = "msg from odd";
                await Clients.Group("Odd").SendAsync("RecieveOddMsg", msg);
            }
            catch (System.Exception ex)
            {
                await Clients.Caller.SendAsync("Notification", ex.Message);
            }
        }

        public async Task SendTestMessageToEvenGroup()
        {
            try
            {
                string msg = "msg from Even";
                await Clients.Group("Odd").SendAsync("RecieveEvenMsg", msg);
            }
            catch (System.Exception ex)
            {
                await Clients.Caller.SendAsync("Notification", ex.Message);
            }
        }
    }
}
