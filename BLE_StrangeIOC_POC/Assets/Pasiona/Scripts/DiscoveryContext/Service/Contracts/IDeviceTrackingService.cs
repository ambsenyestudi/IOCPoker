using Assets.Pasiona.Scripts.DiscoveryContext.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Pasiona.Scripts.DiscoveryContext.Service.Contracts
{
    public interface IDeviceTrackingService
    {
        List<DeviceModel> AvailableDevices { get; }
        void AddDeviceToList(DeviceModel device);
    }
}
