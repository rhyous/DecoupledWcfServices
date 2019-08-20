using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecoupledWcfServices.Tests
{
    [TestClass]
    public class MessageBusTests
    {
        [TestMethod]
        public void MessageBus_GetServiceUri_Test()
        {
            // Arrange
            var bus = new MessageBus();
            var url = "http://localhost:54412/Service2/Service2.svc/GetData";

            // Act
            var actual = bus.GetServiceUri(url);

            // Assert
            Assert.AreEqual("http://localhost:54412/Service2/Service2.svc", actual.AbsoluteUri);
        }
    }
}
