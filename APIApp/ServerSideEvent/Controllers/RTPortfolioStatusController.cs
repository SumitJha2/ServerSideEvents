using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServerSideEvent.Business;
using ServerSideEvent.Helper;
using ServerSideEvent.Helper.Enums;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerSideEvent.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RTPortfolioStatusController : ControllerBase
    {
        TcpClient client = new TcpClient();
        NetworkStream networkStream;
        Stream ms;


        private readonly ILogger<RTPortfolioStatusController> _logger;
        RTPStatusSubscriber obj;
        public RTPortfolioStatusController(ILogger<RTPortfolioStatusController> logger)
        {          
            _logger = logger;          
        }
        [EnableCors("AllowOrigin")]      
        public async Task Get(string clientid, string usertoken, CancellationToken cancellationToken)
        {
            try
            {                
                //if (string.IsNullOrEmpty(Request.Headers["clientid"]))
                //    return new HttpResponseMessage() { StatusCode = HttpStatusCode.Unauthorized };
              
                //if (Request.Headers.TryGetValue("clientid", out var clientid))
                //{
                //    clientId = clientid;
                //}
                
                int clientId = !string.IsNullOrEmpty(clientid) ? int.Parse(clientid) : 1;// 1 will remove when clientId in header will come
                StreamWriter sw = new StreamWriter(HttpContext.Response.Body);
                NotificationPeer np = new NotificationPeer(sw, (int)NotificationPeerRequestTypes.REALTIMEGL, usertoken)
                 {
                    ClientId = clientId,
                 };
               SubscriptionHandlar.AddClient(np); 
               while (!cancellationToken.IsCancellationRequested)
               {
                    await Task.Delay(1000);
               }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
