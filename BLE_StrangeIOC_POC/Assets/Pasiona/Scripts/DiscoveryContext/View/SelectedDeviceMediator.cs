using Assets.Pasiona.Scripts.DiscoveryContext.Controller.Events;
using Assets.Pasiona.Scripts.DiscoveryContext.Model;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Pasiona.Scripts.DiscoveryContext.View
{
    public class SelectedDeviceMediator : EventMediator
    {
        [Inject]
        public SelectedDeviceView View { get; set; }
        public override void OnRegister()
        {
            UpdateListeners(true);
            View.Initialize();
        }
        private void UpdateListeners(bool isListening)
        {

            dispatcher.UpdateListener(isListening, BLE_Events.BLE_DEVICE_DISCOVERED, onDeviceDiscovered);
            View.dispatcher.UpdateListener(isListening, SelectedDeviceView.NEW_SELECTION, onNewSelection);
        }

        private void onNewSelection(IEvent payload)
        {
            dispatcher.Dispatch(ApplicationEvents.DEVICE_SELECTED, payload.data);
        }

        private void onDeviceDiscovered(IEvent payload)
        {
            DeviceModel model = payload.data as DeviceModel;
            View.UpdateList(model);
        }
    }
}
