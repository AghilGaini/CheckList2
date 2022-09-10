using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CheckList2.SignalR
{
    public class SignalRTest : Hub
    {
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
