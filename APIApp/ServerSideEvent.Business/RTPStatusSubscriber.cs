using Newtonsoft.Json;
using ServerSideEvent.Helper.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ServerSideEvent.Business
{
    public class RTPStatusSubscriber
    {
        public void StartMsgGenerator()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 5000;
            timer.Elapsed += new ElapsedEventHandler(GenerateAndSendOB);
            timer.Enabled = true;
            timer.Start();
        }
        private void GenerateAndSendOB(object sender, ElapsedEventArgs e)
        {
            if (SubscriptionHandlar._clients.Count > 0)
            {
                try
                {
                    var clientIds = SubscriptionHandlar._clients.Select(kvp => kvp.ClientId).Distinct().ToList();
                    foreach (int clientId in clientIds)
                    {
                        SendEventAsync(clientId, "MSG_ClientID= " + clientId);
                    }
                }
                catch (Exception ex)
                {

                }

            }
        }
        private static void SendEventAsync(int clientId, string msg)
        {

            foreach (NotificationPeer client in SubscriptionHandlar._clients.Where(e => e.ClientId == clientId && e.PeerRequestType == (int)NotificationPeerRequestTypes.REALTIMEGL))
            {

                try
                {
                    client.StreamWriter.WriteAsync(string.Format("data:{0}_UserID={1}\n\n", msg, client.UserToken));
                    client.StreamWriter.FlushAsync();
                }
                catch (Exception ex)
                {
                    if (ex.Message.StartsWith("The remote host closed the connection"))
                    {
                        // Subsciptionhandler.RemoveClient(client.id);
                    }
                }
            }
        }
    }
}



    

