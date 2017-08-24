using Assets.Pasiona.Scripts.DiscoveryContext.Controller.Events;
using Assets.Pasiona.Scripts.DiscoveryContext.Service.Contracts;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Pasiona.Scripts.DiscoveryContext.Controller.Commands
{
    public class StartScanningCommand : EventCommand
    {
        [Inject]
        public IBLE_Service BLE_Service { get; set; }
        private void updateListeners(bool isListening)
        {
            BLE_Service.Dispatcher.UpdateListener(isListening, BLE_Events.BLE_DEVICE_DISCOVERED, onDeviceDiscovered);
            BLE_Service.Dispatcher.UpdateListener(isListening, BLE_Events.BLE_STOPPED_SCANNING, onStoppedScanning);
            BLE_Service.Dispatcher.UpdateListener(isListening, BLE_Events.BLE_READY, (Payload) => {
                dispatcher.Dispatch(BLE_Events.BLE_READY, Payload.data);
            });
            BLE_Service.Dispatcher.UpdateListener(isListening, BLE_Events.BLE_ERROR, (Payload) => {
                dispatcher.Dispatch(BLE_Events.BLE_ERROR, Payload.data);
            });
        }

        private void onStoppedScanning(IEvent payload)
        {
            updateListeners(false);
            dispatcher.Dispatch(BLE_Events.BLE_STOPPED_SCANNING);
        }

        private void onDeviceDiscovered(IEvent payload)
        {
            dispatcher.Dispatch(BLE_Events.BLE_DEVICE_DISCOVERED, payload.data);
        }

        public override void Execute()
        {

            dispatcher.Dispatch(BLE_Events.BLE_STARTED_SCANNING);
            updateListeners(true);
            BLE_Service.StartScanning();


        }
    }
}
