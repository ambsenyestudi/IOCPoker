using strange.extensions.mediation.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Pasiona.Scripts.DiscoveryContext.Model;
using UnityEngine.UI;
using UnityEngine;

namespace Assets.Pasiona.Scripts.DiscoveryContext.View
{
    public class SelectedDeviceView : EventView
    {
        private Dropdown _dropDown;
        private List<DeviceModel> _deviceList;
        private bool _isListUpdating = false;
        public const string NEW_SELECTION = "NEW_SELECTION";
        public const string NONE_SELECTION = "NONE_SELECTION";
        public void Initialize()
        {
            _deviceList = new List<DeviceModel> { null};
            _dropDown = gameObject.GetComponent<Dropdown>();
            updateOnSelected(true);
        }

        internal void UpdateList(DeviceModel model)
        {
            updateOnSelected(false);
            _isListUpdating = true;
            _deviceList.Add(model);
            _dropDown.options.Clear();
            foreach (var currModel in _deviceList)
            {
                if (currModel == null)
                {
                    _dropDown.options.Add(new Dropdown.OptionData() { text = "None" });
                }
                else
                {
                    _dropDown.options.Add(new Dropdown.OptionData() { text = currModel.GetPrettyName() });
                }
            }
            
            _dropDown.value = 1;
            _dropDown.value = 0;
            updateOnSelected(true);
            _isListUpdating = false;
        }
        private void updateOnSelected(bool isListenning)
        {
            if (isListenning)
            {
                _dropDown.onValueChanged.AddListener(OnValueSelected);
            }
            else
            {
                _dropDown.onValueChanged.RemoveListener(OnValueSelected);
            }
        }

        private void OnValueSelected(int val)
        {
            DeviceModel model = _deviceList[val];
            if (model != null)
            {
                dispatcher.Dispatch(NEW_SELECTION, model);
            }
            else
            {
                dispatcher.Dispatch(NONE_SELECTION, model);
            }
        }
    }
}
