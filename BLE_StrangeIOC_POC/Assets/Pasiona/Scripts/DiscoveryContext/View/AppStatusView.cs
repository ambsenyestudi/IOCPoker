using strange.extensions.mediation.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

namespace Assets.Pasiona.Scripts.DiscoveryContext.View
{
    public class AppStatusView : EventView
    {
        private Text _textOutput;

        public void Initialize()
        {
            _textOutput = gameObject.GetComponent<Text>();
        }
        public void UpdateStatus(string text)
        {
            _textOutput.text = text;
        }
    }
}
