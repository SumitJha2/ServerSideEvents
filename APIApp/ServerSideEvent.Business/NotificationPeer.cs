using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSideEvent.Business
{
    public class NotificationPeer
    {       
        public StreamWriter StreamWriter;
        public int PeerRequestType;
        public int ClientId;
        public string UserToken;        
        public NotificationPeer(StreamWriter streamWriter, int notificationRequestTypes,string userToken)
        {
            StreamWriter = streamWriter;          
            PeerRequestType = notificationRequestTypes;
            UserToken = userToken;          
        }
      
    }  

}
