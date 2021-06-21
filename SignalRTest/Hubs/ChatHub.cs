
using Microsoft.AspNetCore.SignalR;
using SignalRTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRTest.Hubs
{
    public class ChatHub:Hub
    {
        public async Task SendMessage(Message message )=>
           await Clients.All.SendAsync("receiveMessage", message);

    }
}
