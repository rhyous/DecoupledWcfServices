using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecoupledWcfServices.Tests
{
    [TestClass]
    public class MessageBusTests
    {
        [TestMethod]
        public void MessageBus_GetServiceName_Test()
        {
            // Arrange
            var bus = new MessageBus();
            var url = "http://localhost:54412/Service2/Service2.svc/GetData";

            // Act
            var actual = bus.GetServiceName(url);

            // Assert
            Assert.AreEqual("Service2", actual);
        }
    }
}
