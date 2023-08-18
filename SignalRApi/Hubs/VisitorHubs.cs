using Microsoft.AspNetCore.SignalR;
using SignalRApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApi.Hubs
{
    public class VisitorHubs:Hub
    {
        private readonly VisitorService _visitorService;

        public VisitorHubs(VisitorService visitorService)
        {
            _visitorService = visitorService;
        }
        public async Task GetVisitorList()
        {
            await Clients.All.SendAsync("CallVisitList","bbb");
        }
    }
}
