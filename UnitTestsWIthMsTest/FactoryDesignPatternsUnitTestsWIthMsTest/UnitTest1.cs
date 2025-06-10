

using Microsoft.VisualStudio.TestTools.UnitTesting;
using FactoryDesignPatterns;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace FactoryDesignPatternsUnitTestsWIthMsTest
{
    [TestClass]
    public class TransportFactoryTests
    {
        ITransport transport = null;
        public TransportFactoryTests()
        {
           
        }

        [TestMethod]
        public void GetTransport_ShouldReturnCar_WhenTypeIsCar()
        {
            transport = TransportFactory.GetTransport("Car");
            Assert.IsNotNull(transport);
            Assert.IsInstanceOfType(transport, typeof(Car));
        }

        [TestMethod]
        public void GetTransport_ShouldReturnException_WhenTypeIsInValid()
        {
          
            var ex= Assert.ThrowsException<ArgumentException>( () => TransportFactory.GetTransport("InValid"));
            Assert.AreEqual("Invalid transport type", ex.Message);
        }
    }
}