using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace DataExtractor.Handlers
{
    class HTTPHandler
    {

        public HTTPHandler()
        {
        }

        public void PostMasterEntity(string uri, string json) 
        {
            // create a request
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(uri); 
            request.KeepAlive = false;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";

            // turn our request string into a byte stream
            byte[] postBytes = Encoding.ASCII.GetBytes(json);

            // this is important - make sure you specify type this way
            request.ContentType = "application/json; charset=utf-8";
            request.ContentLength = postBytes.Length;
            Stream requestStream = request.GetRequestStream();

            // now send it
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();

            // grab te response and print it out to the console along with the status code
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine(new StreamReader(response.GetResponseStream()).ReadToEnd());
            Console.WriteLine(response.StatusCode);
        }
    }
}
