using Assets.Pasiona.Scripts.DiscoveryContext.Controller.Events;
using Assets.Pasiona.Scripts.DiscoveryContext.Service.Contracts;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Pasiona.Scripts.DiscoveryContext.Controller.StartupSequence
{
    public class StartAppCommand : EventCommand
    {
        [Inject(ContextKeys.CONTEXT_VIEW)]
        public GameObject contextView { get; set; }

        [Inject(ContextKeys.CONTEXT)]
        public IContext context { get; set; }
        [Inject]
        public IDiscovery_Service BLE_Service { get; set; }
        private void updateListeners(bool isListening)
        {
            BLE_Service.Dispatcher.UpdateListener(isListening, BLE_Events.BLE_READY, (Payload) => {
                dispatcher.Dispatch(BLE_Events.BLE_READY, Payload.data);
            });
            BLE_Service.Dispatcher.UpdateListener(isListening, BLE_Events.BLE_ERROR, (Payload) => {
                dispatcher.Dispatch(BLE_Events.BLE_ERROR, Payload.data);
            });
        }
        public override void Execute()
        {
            dispatcher.Dispatch(ApplicationEvents.APPLICATION_LOADED, "Application Loaded Succesfully");
            updateListeners(true);
            BLE_Service.InitializeBridge();
        }

    }
}
