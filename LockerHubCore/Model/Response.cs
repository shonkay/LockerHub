using System;
using System.Collections.Generic;
using System.Text;

namespace LockerHubCore.Model
{
    public class Response
    {
        public List<Response_Model> ModelResponse { get; set; }
        public int TotalLockerAvailable { get; set; }
    }
}
