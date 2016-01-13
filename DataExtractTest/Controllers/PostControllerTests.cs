using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DataExtractor.Controllers;
using DataExtractor.Model;
using DataExtractor.Handlers;
using DataExtractor.Parser;

namespace DataExtractTest.Controllers
{
    [TestClass]
    public class PostControllerTests
    {
        MasterEntity entity;
        Mock<IHTTPHandler> httpHandlerMoq;
        Mock<IDataExtract> dataExtractMoq;
        

        private PostController Setup() 
        {
            entity = new MasterEntity(new EnvironmentData {logTime = DateTime.Now }, null, null);

            httpHandlerMoq = new Mock<IHTTPHandler>();
            dataExtractMoq = new Mock<IDataExtract>();
            dataExtractMoq.Setup(m => m.GetData()).Returns(entity);
            //httpHandlerMoq.Setup(m => m.PostMasterEntity)).


            var sut = new PostController("", httpHandlerMoq.Object, dataExtractMoq.Object);
            return sut;
        }

        [TestMethod]
        public void ExtractAndSerializeData_PostsCorrectJson()
        {
            // Assemble
            var sut = Setup();
            JSONParser parser = new JSONParser();

            // Act
            string json = parser.SerializeObject(entity);
            sut.ExtractAndSerializeData();

            //Verify
            httpHandlerMoq.Verify(m => m.PostMasterEntity("", json), "PostMasterEntity was not called");
        }
    }
}
