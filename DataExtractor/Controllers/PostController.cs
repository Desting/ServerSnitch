using DataExtractor.Handlers;
using DataExtractor.Model;
using DataExtractor.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataExtractor.Controllers
{
   public class PostController
    {
       private string uri;
       private IHTTPHandler httpHandler = new HTTPHandler();
       private IDataExtract dataExtractor = new DataExtract();

       public PostController(string uri)
       {
           this.uri = uri;
       }

       public PostController(string uri, IHTTPHandler httpHandler, IDataExtract dataExtractor)
           :this(uri)
       {
           this.httpHandler = httpHandler;
           this.dataExtractor = dataExtractor;
       }

       //Test this
       public void ExtractAndSerializeData()
       {
           // Initialize MasterEntity to hold data
           MasterEntity dataStorage = dataExtractor.GetData();


           // Serialize to JSON
           JSONParser parser = new JSONParser();
           string json = parser.SerializeObject(dataStorage);

           //System.IO.File.WriteAllText(@"C:\Users\extadmnizi\Desktop\json.txt", json);


           //Post Data
           httpHandler.PostMasterEntity(uri, json);


       }


       

    }
}
