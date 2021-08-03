using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerSideEvent.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSideEvent.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [ActionName("Test")]
        [AcceptVerbs("GET")]
        public IActionResult Test()
        {
            return Ok(SubscriptionHandlar._clients.Count() + 3);
        }
    }
}
