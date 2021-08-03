using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;

namespace ServerSideEvent.Business
{
    public static class SubscriptionHandlar
    {       
      
        public static List<NotificationPeer> _clients = new List<NotificationPeer>();       
        public static void AddClient(NotificationPeer client)
        {
            _clients.Add(client);
        }
       
    }
}
