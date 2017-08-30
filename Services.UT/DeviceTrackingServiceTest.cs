using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assets.Pasiona.Scripts.DiscoveryContext.Model;
using Assets.Pasiona.Scripts.DiscoveryContext.Service.Implementation;
using System.Linq;

namespace Services.UT
{
    [TestClass]
    public class DeviceTrackingServiceTest
    {
        DeviceModel _firstDevice;
        DeviceModel _secondDevice;
        DeviceTrackingService _trackingService;

        [TestInitialize]
        public void InitTrackingTests()
        {
            _firstDevice = new DeviceModel
            {
                ID = "12:34:56:789",
                Name = "first"
            };
            _secondDevice = new DeviceModel
            {
                ID = "123:457:689:000",
                Name = "seconds"
            };
            _trackingService = new DeviceTrackingService();
        }
        [TestMethod]
        public void AvailableDeviceSingleAddTest()
        {
            _trackingService.AddDeviceToList(_firstDevice);
            Assert.AreEqual(_trackingService.AvailableDevices.First(), _firstDevice);
        }
        [TestMethod]
        public void AvailableDeviceDoubleAddTest()
        {
            _trackingService.AddDeviceToList(_firstDevice);
            _trackingService.AddDeviceToList(_secondDevice);
            Assert.AreEqual(_trackingService.AvailableDevices.First(), _firstDevice);
            Assert.AreEqual(_trackingService.AvailableDevices[1], _secondDevice);
        }
        [TestMethod]
        public void AvoidRepeatedInstanceAddTest()
        {
            _trackingService.AddDeviceToList(_firstDevice);
            _trackingService.AddDeviceToList(_firstDevice);
            Assert.AreEqual(_trackingService.AvailableDevices.Count, 1);
            Assert.AreEqual(_trackingService.AvailableDevices.First(), _firstDevice);
        }
        [TestMethod]
        public void AvoidRepeatedIdAddTest()
        {
            _trackingService.AddDeviceToList(_firstDevice);

            _secondDevice.ID = _firstDevice.ID;
            
            _trackingService.AddDeviceToList(_secondDevice);
            Assert.AreEqual(_trackingService.AvailableDevices.Count, 1);
            Assert.AreEqual(_trackingService.AvailableDevices.First(), _firstDevice);
        }
    }
}
