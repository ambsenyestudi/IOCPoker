using Assets.Pasiona.Scripts.DiscoveryContext.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Pasiona.Scripts.DiscoveryContext.Model;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using Assets.Pasiona.Scripts.DiscoveryContext.Controller.Events;
using startechplus.ble;

namespace Assets.Pasiona.Scripts.DiscoveryContext.Service.Implementation
{
    public class ConnectToDeviceService : IConnectToDeviceService
    {
        [Inject]
        public IEventDispatcher Dispatcher { get; set; }
        [Inject]
        public IBLE_Factory BLE_Factory { get; set; }

        private IBleBridge _bleBridge = null;

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
        
        private void connectToSelectedDevice()
        {
            if(_bleBridge == null)
            {
                _bleBridge = BLE_Factory.DefaultBleBridge;
            }
            bool isConnectionPossible = _selectedDevice != null;
            if (_selectedDevice.ID != null)
            {
                
                _bleBridge.ConnectToPeripheralWithIdentifier(_selectedDevice.ID, this.ConnectedPeripheralAction, this.DiscoveredServiceAction,
                                                            this.DiscoveredCharacteristicAction, this.DiscoveredDescriptorAction, this.DisconnectedPeripheralAction);
                
            }
            else
            {
                //TODO Error management for no selected device
            }
        }

        private void DisconnectedPeripheralAction(string peripheralId, string name)
        {
            string msg = string.Format("Device {0} is Disconnected now", name);
            Dispatcher.Dispatch(BLE_Events.BLE_DEVICE_DISCONNECTED, msg);
        }

        private void DiscoveredDescriptorAction(string peripheralId, string serviceName, string characteristic, string descriptor)
        {

            string msg = string.Format("New descriptor discovered:{4} for charasteristic{3} for service {0}, for {1}", serviceName, SelectedDevice.GetPrettyName(), characteristic);
            Dispatcher.Dispatch(BLE_Events.BLE_CONNECTION_STATE_UPDATE, msg);
        }

        private void DiscoveredCharacteristicAction(string peripheralId, string serviceName, string characteristic)
        {
            string msg = string.Format("New charasteristic discovered: {3} for service {0}, for {1}", serviceName, SelectedDevice.GetPrettyName(), characteristic);
            Dispatcher.Dispatch(BLE_Events.BLE_CONNECTION_STATE_UPDATE, msg);
        }

        private void DiscoveredServiceAction(string peripheralId, string serviceName)
        {
            string msg = string.Format("New service discovered: {0}, for {1}", serviceName, SelectedDevice.GetPrettyName());
            Dispatcher.Dispatch(BLE_Events.BLE_CONNECTION_STATE_UPDATE, msg);
            //TODO fire ConnectionUpdate event
        }

        private void ConnectedPeripheralAction(string peripheralId, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = "no_Name";
            }
            string msg = string.Format("Conncetion established to {0} ID {1}", 
                name, peripheralId, SelectedDevice.Name, SelectedDevice.ID);
            Dispatcher.Dispatch(BLE_Events.BLE_CONNECTION_ESTABLISHED, msg);
        }

        public bool EstablishConnection()
        {
            bool isConnectionPossible = _selectedDevice != null;
            if (isConnectionPossible)
            {
                Dispatcher.Dispatch(BLE_Events.BLE_TRYING_TO_ESTABLISH_CONNECTION, _selectedDevice);
                connectToSelectedDevice();
            }
            else
            {
                Debug.Log("(Warnning) You must choose a device to connect to ");
            }
            return isConnectionPossible;
        }
    }
}
