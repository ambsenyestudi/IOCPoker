using strange.extensions.mediation.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using strange.extensions.dispatcher.eventdispatcher.api;
using Assets.Pasiona.Scripts.DiscoveryContext.Controller.Events;

namespace Assets.Pasiona.Scripts.DiscoveryContext.View
{
    public class ConnectBtnMediator : EventMediator
    {

        [Inject]
        public ConnectBtnView View { get; set; }

        public override void OnRegister()
        {
            View.Init();
            UpdateListeners(true);
        }
        private void UpdateListeners(bool value)
        {
            View.dispatcher.UpdateListener(value, ConnectBtnView.CONNECTION_CLICK_EVENT, onStartConnectingClick);
            dispatcher.UpdateListener(value, BLE_Events.BLE_DEVICE_AVAILABLE_FOR_CONNECTION, onDeviceSelected);
            dispatcher.UpdateListener(value, BLE_Events.BLE_NO_DEVICE_FOR_CONNECTION, onNoDevice);
        }

        private void onNoDevice(IEvent payload)
        {
            View.UpdateBtnState(false);
        }

        private void onDeviceSelected(IEvent payload)
        {
            View.UpdateBtnState(true);
        }

        private void onStartConnectingClick(IEvent payload)
        {
            dispatcher.Dispatch(ApplicationEvents.ESTABLISH_CONNECTION_TO_DEVICE);
        }
    }
}
