using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace TestSignalR2
{
    public class MyChatHub : Hub
    {
        public void MyChatSend(string name, string message)
        {
            Clients.All.broadcastMessage(name, message);
            Clients.Caller.boardcastMessage(name, message);
        }
        public void MyChatSendTo(string name, string message, string to)
        {
            Clients.All.broadcastMessage(name, message, to);
            Clients.Caller.boardcastMessage(name, message, to);
        }
        public void MyChatOnline(string name)
        {
            Clients.All.updateStatus(name,"online");
        }
        public void MyChatOffline(string name)
        {
            Clients.All.updateStatus(name,"offline");
        }
        public void MyChatUpdateState(string name, int newState)
        {
            var state = "";
            switch (newState)
            {
                case 0:
                    state = "Connected";
                    break;
                case 1:
                    state = "Connecting";
                    break;
                case 2:
                    state = "Disconnected";
                    break;
                case 4:
                    state = "Reconnecting";
                    break;
                default:
                    break;
            }
            Clients.All.updateStatus(name, state);
        }
    }
}