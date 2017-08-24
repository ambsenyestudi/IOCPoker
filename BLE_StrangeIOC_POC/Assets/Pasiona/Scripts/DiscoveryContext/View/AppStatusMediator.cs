using Assets.Pasiona.Scripts.DiscoveryContext.Controller.Events;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Pasiona.Scripts.DiscoveryContext.View
{
    public class AppStatusMediator : EventMediator
    {
        [Inject]
        public AppStatusView View { get; set; }

        public override void OnRegister()
        {
            UpdateListeners(true);
            View.Initialize();
        }
        private void UpdateListeners(bool value)
        {
            dispatcher.UpdateListener(value, ApplicationEvents.APPLICATION_LOADED, updateMessage);
            dispatcher.UpdateListener(value, ApplicationEvents.SCANNING_UPDATE, updateMessage);
            dispatcher.UpdateListener(value, BLE_Events.BLE_STOPPED_SCANNING, onStopScanning);
        }

        private void onStopScanning(IEvent payload)
        {
            string message = "Scanning process ended";
            View.UpdateStatus(message);
        }

        private void updateMessage(IEvent payload)
        {
            string message = payload.data as string;
            View.UpdateStatus(message);
        }

        public override void OnRemove()
        {
            UpdateListeners(false);
        }
    }
}
