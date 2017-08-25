using Assets.Pasiona.Scripts.DiscoveryContext.Controller.Events;
using Assets.Pasiona.Scripts.DiscoveryContext.Model;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Pasiona.Scripts.DiscoveryContext.View
{
    public class EventLogMediator : EventMediator
    {
        [Inject]
        public EventLogView View { get; set; }
        private void updateListeners(bool isListening)
        {
            dispatcher.UpdateListener(isListening, BLE_Events.BLE_STARTED_SCANNING, onStartScanning);
            dispatcher.UpdateListener(isListening, BLE_Events.BLE_DEVICE_DISCOVERED, onDeviceDiscovered);
            dispatcher.UpdateListener(isListening, BLE_Events.BLE_STOPPED_SCANNING, onBLE_Stopped);
            dispatcher.UpdateListener(isListening, BLE_Events.BLE_READY, onStatusInfoRecieved);
            dispatcher.UpdateListener(isListening, BLE_Events.BLE_ERROR, onStatusInfoRecieved);
            dispatcher.UpdateListener(isListening, BLE_Events.BLE_TRYING_TO_ESTABLISH_CONNECTION, onTryingToEstablishConnection);
        }

        private void onTryingToEstablishConnection(IEvent payload)
        {
            DeviceModel model = payload.data as DeviceModel;
            string message = string.Format("Trying to establish data to {0}", model.GetPrettyName());
            View.UpdateEventLog(message, true);
        }

        private void onStatusInfoRecieved(IEvent payload)
        {
            string message = payload.data as string;
            View.UpdateEventLog(message, true);
        }

        private void onStartScanning(IEvent payload)
        {
            View.UpdateEventLog("Starting to scan", true);
        }

        private void onBLE_Stopped(IEvent payload)
        {
            View.UpdateEventLog("Scanning Time finished", true, true);
        }

        private void onDeviceDiscovered(IEvent payload)
        {
            DeviceModel model = payload.data as DeviceModel;
            if (model != null)
            {
                View.DeviceDiscoveredEvent(model);
            }

        }

        public override void OnRegister()
        {
            updateListeners(true);
            View.Init();
        }
        public override void OnRemove()
        {
            updateListeners(false);
        }


    }
}
