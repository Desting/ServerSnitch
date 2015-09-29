using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataExtractor.Parser;

namespace DataExtractTest.DataExtractorTest.Parser
{
    [TestClass]
    public class ParserTests
    {

      



        [TestMethod]
        public void JsonParseProductClass()
        {
            Product product = new Product(1, "Pen", 50);

            JSONParser parser = new JSONParser();

            string result = parser.SerializeObject(product);


            string json = "{\"id\":1,\"name\":\"Pen\",\"price\":50}";

            Assert.AreEqual(result, json);

        }


        class Product
        {
            public int id { get; set; }
            public string name { get; set; }
            public int price { get; set; }

            public Product(int id, string name, int price)
            {
                this.id = id;
                this.name = name;
                this.price = price;
            }


        }
    }
}
