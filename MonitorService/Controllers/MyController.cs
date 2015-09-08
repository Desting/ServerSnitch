using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MonitorService.Controllers
{
    public class MyController : ApiController
    {

        public class Product
        {
            public int id { get; set; }
            public string name { get; set; }
            public string type { get; set; }

        }



        public IEnumerable<Product> Get()
        {
            return new List<Product> 
            {
            new Product {id = 1, name = "Schwitz", type = "knife"},
            new Product {id = 2, name = "bjorn", type = "wallet"},
            new Product {id = 1, name = "galaxy", type = "samsung"},
            
            };
        }

        public string Post([FromBody] Product product) 
        {
            Console.Write(product.ToString());
            return "OK";
        }


        
    }
}
