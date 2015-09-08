using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataExtractor.Parser
{
    class JSONParser
    {

        public JSONParser()
        {

        }

        public string SerializeObject(Object data) 
        {
            string json = JsonConvert.SerializeObject(data);
            return json;
        }

        public void SaveToFile(string path, string json) 
        {
            System.IO.File.WriteAllText(path, json);
        }


    }
}
