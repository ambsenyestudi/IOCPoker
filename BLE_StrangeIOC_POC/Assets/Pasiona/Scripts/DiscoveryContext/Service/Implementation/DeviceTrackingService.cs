using Assets.Pasiona.Scripts.DiscoveryContext.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Pasiona.Scripts.DiscoveryContext.Model;

namespace Assets.Pasiona.Scripts.DiscoveryContext.Service.Implementation
{
    public class DeviceTrackingService : IDeviceTrackingService
    {
        private List<DeviceModel> _availableDevices;
        public List<DeviceModel> AvailableDevices
        {
            get
            {
                return _availableDevices;
            }
        }
        public DeviceTrackingService()
        {
            _availableDevices = new List<DeviceModel>();
        }
        private bool isInAvailableDevices(DeviceModel device)
        {
            bool isFound = AvailableDevices.Contains(device);

            int count = 0;
            while(!isFound && count < AvailableDevices.Count)
            {
                isFound = AvailableDevices[count].ID == device.ID;
                count++;
            }
            return isFound;
        }
        public void AddDeviceToList(DeviceModel device)
        {
            if (!isInAvailableDevices(device))
            {
                _availableDevices.Add(device);
            }
        }
    }
}
