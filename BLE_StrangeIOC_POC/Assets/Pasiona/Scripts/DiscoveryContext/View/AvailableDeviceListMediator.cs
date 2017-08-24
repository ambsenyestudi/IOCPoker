using strange.extensions.mediation.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using strange.extensions.dispatcher.eventdispatcher.api;
using Assets.Pasiona.Scripts.DiscoveryContext.Controller.Events;
using Assets.Pasiona.Scripts.DiscoveryContext.Model;

namespace Assets.Pasiona.Scripts.DiscoveryContext.View
{
    public class AvailableDeviceListMediator : EventMediator
    {
        [Inject]
        public AvailableDeviceListView View { get; set; }

        public override void OnRegister()
        {
            UpdateListeners(true);
            View.Initialize();
        }
        private void UpdateListeners(bool isListening)
        {

            dispatcher.UpdateListener(isListening, BLE_Events.BLE_DEVICE_DISCOVERED, onDeviceDiscovered);
        }

        private void onDeviceDiscovered(IEvent payload)
        {
            DeviceModel model = payload.data as DeviceModel;
            View.UpdateList(model);
        }
    }
}
