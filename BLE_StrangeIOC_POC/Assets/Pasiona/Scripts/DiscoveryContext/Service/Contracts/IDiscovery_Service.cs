using Assets.Pasiona.Scripts.DiscoveryContext.Model;
using strange.extensions.dispatcher.eventdispatcher.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Pasiona.Scripts.DiscoveryContext.Service.Contracts
{
    public interface IDiscovery_Service
    {
        void InitializeBridge();
        IBLE_Factory BLE_Factory { get; set; }
        IDeviceTrackingService DeviceTrackingService { get; set; }
        IEventDispatcher Dispatcher { get; set; }
        void StartScanning();
        void StopScanning();
    }
}
