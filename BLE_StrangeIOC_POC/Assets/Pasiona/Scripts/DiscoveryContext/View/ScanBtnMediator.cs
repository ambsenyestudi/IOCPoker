using Assets.Pasiona.Scripts.DiscoveryContext.Controller.Events;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Pasiona.Scripts.DiscoveryContext.View
{
    public class ScanBtnMediator : EventMediator
    {
        [Inject]
        public ScanBtnView View { get; set; }

        public override void OnRegister()
        {
            View.Init();
            UpdateListeners(true);
        }
        private void UpdateListeners(bool value)
        {
            View.dispatcher.UpdateListener(value, ScanBtnView.CLICK_EVENT, onStartScanningClick);
            View.dispatcher.UpdateListener(value, ScanBtnView.SCANNING_TIME_FINISHED, onScanningTimeFinished);
            View.dispatcher.UpdateListener(value, ScanBtnView.RUNNING_SCAN, onScanningRunning);
        }

        private void onScanningRunning(IEvent payload)
        {
            dispatcher.Dispatch(ApplicationEvents.SCANNING_UPDATE, payload.data);
        }

        private void onStartScanningClick(IEvent payload)
        {
            dispatcher.Dispatch(BLE_Events.BLE_START_SCANNING);
            View.ResetCoountDown();
            View.StartCoroutine(View.CountDown());
        }

        private void onScanningTimeFinished(IEvent payload)
        {
            dispatcher.Dispatch(BLE_Events.BLE_STOP_SCANNING);
        }
    }
}
