﻿using Assets.Pasiona.Scripts.DiscoveryContext.Controller.Events;
using Assets.Pasiona.Scripts.DiscoveryContext.Service.Contracts;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Pasiona.Scripts.DiscoveryContext.Controller.Commands
{
    public class NoDeviceSelectedCommand : EventCommand
    {
        [Inject]
        public IConnectToDeviceService ConnectionService { get; set; }
        private void updateListeners(bool isListening)
        {
            ConnectionService.Dispatcher.UpdateListener(isListening, BLE_Events.BLE_NO_DEVICE_FOR_CONNECTION, onNoDevice);

        }
        private void onNoDevice(IEvent payload)
        {
            dispatcher.Dispatch(BLE_Events.BLE_NO_DEVICE_FOR_CONNECTION);
            updateListeners(false);
        }
        public override void Execute()
        {
            updateListeners(true);
            ConnectionService.SelectedDevice = null;
            
        }
    }
}
