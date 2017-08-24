using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Pasiona.Scripts.DiscoveryContext.View
{
    public class ScanBtnView : EventView
    {
        public Button ScanButton;
        internal const string CLICK_EVENT = "CLICK_EVENT";
        internal const string SCANNING_TIME_FINISHED = "SCANNING_TIME_FINISHED";
        internal const string RUNNING_SCAN = "RUNNING_SCAN";
        const int MAX_SCANSECONDS = 5;
        int currSeconds = 0;
        public void Init()
        {
            ScanButton.interactable = true;
            ScanButton.onClick.AddListener(ScanClicked);
        }

        private void ScanClicked()
        {
            dispatcher.Dispatch(CLICK_EVENT);
        }
        public void ResetCoountDown()
        {
            currSeconds = 0;
        }
        public IEnumerator CountDown()
        {
            while (currSeconds < MAX_SCANSECONDS)
            {
                if (currSeconds == 0)
                {
                    ScanButton.interactable = false;
                }
                currSeconds++;
                dispatcher.Dispatch(RUNNING_SCAN, string.Format("Sanning for devices, time left {0}", MAX_SCANSECONDS-currSeconds));
                yield return new WaitForSeconds(1f);
            }
            ScanButton.interactable = true;
            StopCoroutine(CountDown());
            dispatcher.Dispatch(SCANNING_TIME_FINISHED);

        }
    }
}
