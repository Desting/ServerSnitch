using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MonitorService.Controllers
{
    public class ServerDataController : ApiController
    {

        public string Post([FromBody] string content)
        {
            System.IO.File.WriteAllText(@"C:\Users\Public\Recieved.txt", content);
            return "OK";
        }

    }
}
