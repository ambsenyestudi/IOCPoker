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
        private RectTransform _parentRect;
        public void Initialize()
        {
            _deviceList = new List<DeviceModel>();
            int childrenCount = gameObject.transform.childCount;
            _parentRect = transform.GetComponent<RectTransform>();
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
        private GameObject generateBlackText(string text, TextAnchor anchor = TextAnchor.MiddleCenter)
        {
            GameObject textGo = new GameObject();

            textGo.AddComponent<Text>();
            Text textComp = textGo.GetComponent<Text>();
            textComp.alignment = anchor;

            Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
            textComp.font = ArialFont;
            textComp.material = ArialFont.material;

            textComp.color = Color.black;
            textComp.text = text;
            RectTransform rt = textGo.GetComponent<RectTransform>();


            rt.anchorMin = new Vector3(1, 0);
            rt.anchorMax = new Vector3(1, 0);
            rt.pivot = new Vector2(0.5f, 0.5f);
            return textGo;
        }
        private GameObject instantiateText(string text)
        {
            GameObject nameGo = generateBlackText(text, TextAnchor.MiddleRight);
            return nameGo;
            /*
            GameObject nameGo = new GameObject();
            
            nameGo.AddComponent<Text>();
            Text textComp = nameGo.GetComponent<Text>();
            textComp.alignment = TextAnchor.MiddleRight;
            
            Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
            textComp.font = ArialFont;
            textComp.material = ArialFont.material;
            
            textComp.color = Color.black;
            textComp.text = text;
            RectTransform rt = nameGo.GetComponent<RectTransform>();
            
            
            rt.anchorMin = new Vector3(1, 0);
            rt.anchorMax = new Vector3(1, 0);
            rt.pivot = new Vector2(0.5f, 0.5f);
            return nameGo;
            */
        }
        public GameObject generateTwoTextPanel(string id, string text)
        {
            GameObject panel = new GameObject();
            RectTransform rt = panel.AddComponent<RectTransform>();
            rt.anchorMin = new Vector3(1, 0);
            rt.anchorMax = new Vector3(1, 0);
            rt.pivot = new Vector2(0.5f, 0.5f);
            HorizontalLayoutGroup horizontalLayoutGroup = panel.AddComponent<HorizontalLayoutGroup>();
            horizontalLayoutGroup.childControlHeight = true;
            horizontalLayoutGroup.childControlWidth = true;
            horizontalLayoutGroup.childForceExpandHeight = true;
            horizontalLayoutGroup.childForceExpandWidth = true;
            horizontalLayoutGroup.padding = new RectOffset { left = 10, right = 10 };

            panel.AddComponent<CanvasRenderer>();

            GameObject leftText = generateBlackText(id, TextAnchor.MiddleLeft);
            leftText.transform.parent = panel.transform;
            GameObject RightText = generateBlackText(text, TextAnchor.MiddleRight);
            RightText.transform.parent = panel.transform;
            return panel;
        }
        private void updateListView()
        {
            clearChildren();
            for (int i = 0; i < _deviceList.Count; i++)
            {

                GameObject newText = generateTwoTextPanel(_deviceList[i].ID, _deviceList[i].GetPrettyName());
                newText.transform.parent = transform;
            }
        }
    }
}

