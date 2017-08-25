using strange.extensions.mediation.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Pasiona.Scripts.DiscoveryContext.View
{
    public class ConnectBtnView : EventView
    {
        public Button ScanButton;
        internal const string CONNECTION_CLICK_EVENT = "CONNECTION_CLICK_EVENT";

        public void Init()
        {
            ScanButton.interactable = false;
            ScanButton.onClick.AddListener(ConnectClicked);
        }

        private void ConnectClicked()
        {
            dispatcher.Dispatch(CONNECTION_CLICK_EVENT);
        }

        internal void UpdateBtnState(bool isDevice)
        {
            ScanButton.interactable = isDevice;
        }
    }
}
