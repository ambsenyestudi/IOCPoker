using Assets.Pasiona.Scripts.DiscoveryContext.Model;
using strange.extensions.dispatcher.eventdispatcher.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Pasiona.Scripts.DiscoveryContext.Service.Contracts
{
    public interface IBLE_Service
    {
        void InitializeBridge();
        IEventDispatcher Dispatcher { get; set; }
        void StartScanning();
        void StopScanning();
        bool ConnectToDevice(DeviceModel deviceModel);

        void DisconnectFromDevice();
    }
}
