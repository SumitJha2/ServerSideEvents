using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServerSideEvent.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServerSideEvent.BackgroundServices
{
    public class SendNotification : IHostedService,IDisposable
    {
        public readonly ILogger<SendNotification> _logger;
        RTPStatusSubscriber obj;
        public SendNotification(ILogger<SendNotification> logger)
        {
            _logger = logger;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Send notification");
            obj = new RTPStatusSubscriber();
            obj.StartMsgGenerator();           
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Send notification");
            return Task.CompletedTask;
        }
        public void Dispose()
        {

        }
    }
}
