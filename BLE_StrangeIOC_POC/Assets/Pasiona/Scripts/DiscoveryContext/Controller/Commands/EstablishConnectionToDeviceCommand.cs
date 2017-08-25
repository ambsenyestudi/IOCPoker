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
    public class EstablishConnectionToDeviceCommand : EventCommand
    {
        [Inject]
        public IConnectToDeviceService ConnectionService { get; set; }

        private void updateListeners(bool isListening)
        {
            ConnectionService.Dispatcher.UpdateListener(isListening, BLE_Events.BLE_TRYING_TO_ESTABLISH_CONNECTION, OnConnectionStarting);
            
        }

        public void OnConnectionStarting(IEvent payload)
        {
            dispatcher.Dispatch(BLE_Events.BLE_TRYING_TO_ESTABLISH_CONNECTION, payload.data);
            updateListeners(false);
        }
        public override void Execute()
        {
            updateListeners(true);
            ConnectionService.EstablishConnection();
        }
    }
}
