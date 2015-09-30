using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataExtractor.Controllers;
using DataExtractor.Model;
using DataExtractor.Handlers;
using Moq;
using DataExtractor.Model.IIS;
using System.Collections.Generic;

namespace DataExtractTest.Controllers
{
    [TestClass]
    public class ControllerTests
    {
        EnvironmentData envData;
        Mock<IEnvironmentHandler> eHandlerMoq;
        Mock<IIisHandler> iisHandlerMoq;
        Mock<IServiceHandler> servHandlerMoq;
        private Controller Setup()
        {
            envData = new EnvironmentData(null, null, null, null, null);
            eHandlerMoq = new Moq.Mock<IEnvironmentHandler>();
            eHandlerMoq.Setup(m => m.GetEnvironmentData()).Returns(envData);
            iisHandlerMoq = new Moq.Mock<IIisHandler>();
            servHandlerMoq = new Mock<IServiceHandler>();

            var sut = new Controller("", eHandlerMoq.Object, iisHandlerMoq.Object, servHandlerMoq.Object);
            return sut;
        }

        [TestMethod]
        public void GetData_ReturnsEnvironmentData()
        {
            //Assemble
            var sut = Setup();

            //Act
            MasterEntity result = sut.GetData();

            //Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void GetData_HasIIS_StoresIISdata()
        {
            //Assemble
            var sut = Setup();
            iisHandlerMoq.Setup(m => m.GetIisVersion()).Returns(new Version());
            iisHandlerMoq.Setup(m => m.StoreIIS(It.IsAny<IISData>())).Returns(new IISStringContainer());

            //Act
            MasterEntity result = sut.GetData();

            //Assert
            Assert.IsNotNull(result.iis);
        }


        // --------------------------- Nikolaj alene ---------------------------

        [TestMethod]
        public void GetData_HasIIS_CallsCreateIisDataObject()
        {
            //Assemble
            var sut = Setup();
            var version = new Version();
            var iisData = new IISData();
            iisHandlerMoq.Setup(m => m.GetIisVersion()).Returns(version);
            iisHandlerMoq.Setup(m => m.CreateIisDataObject(version)).Returns(iisData);
            iisHandlerMoq.Setup(m => m.StoreIIS(iisData)).Returns(new IISStringContainer());

            //Act
            MasterEntity result = sut.GetData();

            //Assert
            iisHandlerMoq.Verify(m => m.CreateIisDataObject(version), "GetIisVersion was not called");
            iisHandlerMoq.Verify(m => m.StoreIIS(iisData), "GetIisVersion was not called");
        }



        [TestMethod]
        public void GetData_ListsServices()
        {
            //Assemble
            var sut = Setup();
            var servList = new List<ServiceData>();
            servHandlerMoq.Setup(m => m.ListServices()).Returns(servList);

            //Act
            MasterEntity result = sut.GetData();

            //Assert
            Assert.IsNotNull(result.applications);

        }
    }
}
