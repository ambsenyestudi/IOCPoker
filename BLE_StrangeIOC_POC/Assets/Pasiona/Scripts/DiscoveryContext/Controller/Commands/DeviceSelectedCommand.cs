using Assets.Pasiona.Scripts.DiscoveryContext.Model;
using strange.extensions.command.impl;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using Assets.Pasiona.Scripts.DiscoveryContext.Service.Contracts;
using Assets.Pasiona.Scripts.DiscoveryContext.Controller.Events;
using strange.extensions.dispatcher.eventdispatcher.api;

namespace Assets.Pasiona.Scripts.DiscoveryContext.Controller.Commands
{
    public class DeviceSelectedCommand : EventCommand
    {
        [Inject]
        public IConnectToDeviceService ConnectionService { get; set; }
        private void updateListeners(bool isListening)
        {
            ConnectionService.Dispatcher.UpdateListener(isListening, BLE_Events.BLE_DEVICE_AVAILABLE_FOR_CONNECTION, onDeviceAvailable);
            
        }
        private void onDeviceAvailable(IEvent payload)
        {
            dispatcher.Dispatch(BLE_Events.BLE_DEVICE_AVAILABLE_FOR_CONNECTION, payload.data);
            updateListeners(false);
        }

        public override void Execute()
        {
            updateListeners(true);
            DeviceModel model = evt.data as DeviceModel;
            ConnectionService.SelectedDevice = model;
            
        }
    }
}
