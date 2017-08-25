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
            ConnectionService.Dispatcher.UpdateListener(isListening, BLE_Events.BLE_CONNECTION_ESTABLISHED, OnConnectionEstablished);
            //ToDo fire a start traking connection command and manage connection error
            ConnectionService.Dispatcher.UpdateListener(isListening, BLE_Events.BLE_CONNECTION_STATE_UPDATE, OnConnectionStateChanged);
            ConnectionService.Dispatcher.UpdateListener(isListening, BLE_Events.BLE_DEVICE_DISCONNECTED, OnDisconnection);
        }

        private void OnConnectionStateChanged(IEvent payload)
        {
            dispatcher.Dispatch(BLE_Events.BLE_CONNECTION_STATE_UPDATE, payload.data);
        }

        private void OnDisconnection(IEvent payload)
        {
            dispatcher.Dispatch(BLE_Events.BLE_DEVICE_DISCONNECTED, payload.data);
        }

        private void OnConnectionEstablished(IEvent payload)
        {
            dispatcher.Dispatch(BLE_Events.BLE_CONNECTION_ESTABLISHED, payload.data);
            
        }

        public void OnConnectionStarting(IEvent payload)
        {
            dispatcher.Dispatch(BLE_Events.BLE_TRYING_TO_ESTABLISH_CONNECTION, payload.data);
        }
        public override void Execute()
        {
            updateListeners(true);
            ConnectionService.EstablishConnection();
        }
    }
}
