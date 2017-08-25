using Assets.Pasiona.Scripts.DiscoveryContext.Model;
using strange.extensions.dispatcher.eventdispatcher.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Pasiona.Scripts.DiscoveryContext.Service.Contracts
{
    public interface IConnectToDeviceService
    {
        IEventDispatcher Dispatcher { get; set; }
        IBLE_Factory BLE_Factory { get; set; }
        DeviceModel SelectedDevice { get; set; }

        bool EstablishConnection();
    }
}
