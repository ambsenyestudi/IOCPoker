using strange.extensions.mediation.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Pasiona.Scripts.DiscoveryContext.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Pasiona.Scripts.DiscoveryContext.View
{
    public class AvailableDeviceListView : EventView
    {
        private List<DeviceModel> _deviceList;
        public void Initialize()
        {
            _deviceList = new List<DeviceModel>();
            int childrenCount = gameObject.transform.childCount;
        }

        public void UpdateList(DeviceModel model)
        {
            _deviceList.Add(model);
            //TODO don't add model if list already contains it
            updateListView();
        }
        private void clearChildren()
        {
            int childrenCount = gameObject.transform.childCount;
            List<GameObject> toClear = new List<GameObject>();
            for (int i = 0; i < childrenCount; i++)
            {
                toClear.Add(gameObject.transform.GetChild(i).gameObject);
            }
            foreach (var child in toClear)
            {
                GameObject.Destroy(child as UnityEngine.Object, 0f);
            }
        }
        private GameObject instantiateText(string text)
        {   GameObject go = new GameObject();
            go.AddComponent<Text>();
            Text textComp = go.GetComponent<Text>();
            textComp.text = text;
            //Need to resize text and fi it tu purpuse and give it size
            return go;
        }
        private void updateListView()
        {
            clearChildren();
            for (int i = 0; i < _deviceList.Count; i++)
            {
                GameObject newText = instantiateText(_deviceList[i].Name);
                newText.transform.parent = transform;
            }
        }
    }
}
