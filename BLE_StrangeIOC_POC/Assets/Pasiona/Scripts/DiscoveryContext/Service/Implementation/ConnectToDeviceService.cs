using Assets.Pasiona.Scripts.DiscoveryContext.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Pasiona.Scripts.DiscoveryContext.Model;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using Assets.Pasiona.Scripts.DiscoveryContext.Controller.Events;

namespace Assets.Pasiona.Scripts.DiscoveryContext.Service.Implementation
{
    public class ConnectToDeviceService : IConnectToDeviceService
    {
        [Inject]
        public IEventDispatcher Dispatcher { get; set; }
        private DeviceModel _selectedDevice;
        public DeviceModel SelectedDevice
        {
            get
            {
                return _selectedDevice;
            }

            set
            {
                _selectedDevice = value;
                if(_selectedDevice != null)
                {
                    Dispatcher.Dispatch(BLE_Events.BLE_DEVICE_AVAILABLE_FOR_CONNECTION, _selectedDevice);
                }
                else
                {
                    Dispatcher.Dispatch(BLE_Events.BLE_NO_DEVICE_FOR_CONNECTION);
                }
            }
        }

        public bool EstablishConnection()
        {
            bool isConnectionSuccesfull = _selectedDevice != null;
            if (isConnectionSuccesfull)
            {
                Dispatcher.Dispatch(BLE_Events.BLE_TRYING_TO_ESTABLISH_CONNECTION, _selectedDevice);
                Debug.Log(string.Format("Trying to establish Connection to {0}", _selectedDevice.GetPrettyName()));
            }
            else
            {
                Debug.Log("(Warnning) You must choose a device to connect to ");
            }
            return isConnectionSuccesfull;
        }
    }
}
