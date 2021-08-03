using System;
using System.Net;

namespace ServerSideEvent.Helper
{
    public class ErrorResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
