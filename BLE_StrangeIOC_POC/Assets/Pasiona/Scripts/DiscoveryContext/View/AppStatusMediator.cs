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
            dispatcher.UpdateListener(value, ApplicationEvents.APPLICATION_LOADED, onAppliationLoaded);
        }

        private void onAppliationLoaded(IEvent payload)
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
