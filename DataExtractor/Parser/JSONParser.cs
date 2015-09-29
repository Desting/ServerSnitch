using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataExtractor.Parser
{
    public class JSONParser
    {

        public JSONParser()
        {

        }

        public string SerializeObject(Object data) 
        {
            string json = JsonConvert.SerializeObject(data);
            return json;
        }



    }
}
