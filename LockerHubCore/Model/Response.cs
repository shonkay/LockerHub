using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace LockerHubCore.Model
{
    public class Response
    {
        public string ResponseMessage { get; set; }
        public HttpStatusCode ResponseCode { get; set; }
        public List<Response_Model> ModelResponse { get; set; }
        public int TotalLockerAvailable { get; set; }
    }
}
