using Assets.Pasiona.Scripts.DiscoveryContext.Controller.Events;
using Assets.Pasiona.Scripts.DiscoveryContext.Model;
using Assets.Pasiona.Scripts.DiscoveryContext.Service.Contracts;
using startechplus.ble;
using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Pasiona.Scripts.DiscoveryContext.Service.Implementation
{
    public class Discovery_Service : IDiscovery_Service
    {
        [Inject]
        public IBLE_Factory BLE_Factory { get; set; }
        [Inject]
        public IEventDispatcher Dispatcher { get; set; }

        private IBleBridge _bleBridge = null;
        public void InitializeBridge()
        {


            _bleBridge = BLE_Factory.DefaultBleBridge;
            //Startup the native side of the code and include our callbacks...
            _bleBridge.Startup(true, this.StartupAction, this.ErrorAction, this.StateUpdateAction, this.DidUpdateRssiAction);

        }

        private void DidUpdateRssiAction(string arg1, string arg2)
        {
            //Todo
            //throw new NotImplementedException();
        }

        private void StateUpdateAction(string message)
        {
            Dispatcher.Dispatch(BLE_Events.BLE_UPDATED, message);
        }

        private void StartupAction()
        {
            Dispatcher.Dispatch(BLE_Events.BLE_READY, "Bluetooth ready to Start Scanning");
        }

        private void ErrorAction(string message)
        {
            Dispatcher.Dispatch(BLE_Events.BLE_ERROR, message);
        }

        public bool ConnectToDevice(DeviceModel deviceModel)
        {
            bool isConnected = false;
            //TODO
            return isConnected;
        }

        public void DisconnectFromDevice()
        {
            //TODO
        }

        public void StartScanning()
        {
            if (_bleBridge == null)
            {
                InitializeBridge();
            }
            if(Application.platform == RuntimePlatform.WindowsEditor)
            {
                fakeScanForDevices();
            }
            else
            {
                startScanningBLE();
            }
            
        }
        private void startScanningBLE()
        {
            _bleBridge.StopScanning();

            _bleBridge.AddAdvertisementDataListeners(this.AdvertiseLocalNameAction,
                                                    this.AdvertiseManufactureDataAction,
                                                    this.AdvertiseServiceDataAction,
                                                    this.AdvertiseServiceAction,
                                                    this.AdvertiseOverflowServiceAction,
                                                    this.AdvertiseTxPowerLevelActionAction,
                                                    this.AdvertiseIsConnectableAction,
                                                    this.AdvertiseSolicitedServiceAction);

            _bleBridge.ScanForPeripheralsWithServiceUUIDs(null, this.DiscoveredPeripheralAction);

        }
        private void DiscoveredPeripheralAction(string arg1, string arg2)
        {
            //throw new NotImplementedException();
        }

        private void AdvertiseTxPowerLevelActionAction(string arg1, string arg2)
        {
            //throw new NotImplementedException();
        }

        private void AdvertiseSolicitedServiceAction(string arg1, string arg2)
        {
            //throw new NotImplementedException();
        }

        private void AdvertiseIsConnectableAction(string arg1, string arg2)
        {
            //throw new NotImplementedException();
        }

        private void AdvertiseOverflowServiceAction(string arg1, string arg2)
        {
            //throw new NotImplementedException();
        }

        private void AdvertiseServiceAction(string arg1, string arg2)
        {
            //throw new NotImplementedException();
        }

        private void AdvertiseServiceDataAction(string arg1, string arg2, byte[] arg3)
        {
            //throw new NotImplementedException();
        }

        private void AdvertiseManufactureDataAction(string arg1, byte[] arg2)
        {
            //throw new NotImplementedException();
        }

        private void AdvertiseLocalNameAction(string peripherialID, string localName)
        {
            Debug.Log("BLE_Service Local" + peripherialID + " " + localName);
            var fakeModel = new DeviceModel
            {
                Name = localName,
                ID = peripherialID
            };
            Dispatcher.Dispatch(BLE_Events.BLE_DEVICE_DISCOVERED, fakeModel);
        }

        public void StopScanning()
        {
            if (_bleBridge == null)
            {
                InitializeBridge();
            }
            Dispatcher.Dispatch(BLE_Events.BLE_STOPPED_SCANNING);
            _bleBridge.StopScanning();
        }
        private void fakeScanForDevices()
        {
            //TODO
            var fakeModel = new DeviceModel
            {
                Name = "Fake_Device",
                ID = "Fake_ID"
            };
            Dispatcher.Dispatch(BLE_Events.BLE_DEVICE_DISCOVERED, fakeModel);
            var newFakeModel = new DeviceModel
            {
                Name = null,
                ID = "Fake_ID"
            };
            Dispatcher.Dispatch(BLE_Events.BLE_DEVICE_DISCOVERED, newFakeModel);
        }
    }
}
