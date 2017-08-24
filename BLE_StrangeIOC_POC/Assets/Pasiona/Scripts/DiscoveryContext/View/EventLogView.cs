using Assets.Pasiona.Scripts.DiscoveryContext.Model;
using strange.extensions.mediation.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Pasiona.Scripts.DiscoveryContext.View
{
    public class EventLogView : EventView
    {
        //This script gos in the Content Child of the ScrollView
        public Text text;
        private string log = String.Empty;
        private RectTransform _contentRectTransform;
        private RectTransform _textRectTransform;
        private string manageModelName(DeviceModel model)
        {
            Debug.Log("geting model name " + model.Name);
            string modelName = model.Name;
            if (string.IsNullOrEmpty(model.Name))
            {
                modelName = string.Format("Device ({0})", model.ID);
            }
            return modelName;
        }


        private string buildNowTimeString()
        {
            return DateTime.Now.ToString("HH:mm:ss.fff MM/dd/yyyy");
        }
        private string buildLogLine(string info)
        {
            string newLog = String.Empty;
            newLog += string.Format("({0}): {1}", buildNowTimeString(), info);
            return newLog;
        }

        internal void Init()
        {
            _textRectTransform = text.GetComponent<RectTransform>();
            _contentRectTransform = gameObject.GetComponent<RectTransform>();
            _contentRectTransform.sizeDelta = new Vector2(0, _textRectTransform.rect.height);
        }

        public void DeviceDiscoveredEvent(DeviceModel model)
        {
            var modelLogLine = string.Format("Device {0} discovered", manageModelName(model));
            UpdateEventLog(modelLogLine);
        }
        public void UpdateEventLog(string currlog, bool isBlockTitle = false, bool isDoubleSpaceNeeded = false)
        {
            currlog = buildLogLine(currlog);
            if (isBlockTitle)
            {
                currlog = "----------------------------------\n" + currlog + "\n----------------------------------\n";
            }
            currlog += "\n";
            if (isDoubleSpaceNeeded)
            {
                currlog += "\n";
            }
            log += currlog;
            text.text = log;
        }
    }
}
