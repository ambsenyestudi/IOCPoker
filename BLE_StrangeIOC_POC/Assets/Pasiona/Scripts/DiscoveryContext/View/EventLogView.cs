﻿using Assets.Pasiona.Scripts.DiscoveryContext.Model;
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
        private ScrollRect _scrollRect;
        private RectTransform _contentRectTransform;
        private RectTransform _textRectTransform;
        internal void Init()
        {
            _scrollRect = gameObject.GetComponentsInParent(typeof(ScrollRect)).FirstOrDefault() as ScrollRect;
                
            _textRectTransform = text.GetComponent<RectTransform>();
            _contentRectTransform = gameObject.GetComponent<RectTransform>();
            _contentRectTransform.sizeDelta = new Vector2(0, _textRectTransform.rect.height);
        }
        private string manageModelName(DeviceModel model)
        {
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
        
        public void DeviceDiscoveredEvent(DeviceModel model)
        {
            var modelLogLine = string.Format("Device {0} discovered", manageModelName(model));
            UpdateEventLog(modelLogLine);
        }
        public float figureScrollPosition()
        {
            int lineCount = log.Split('\n').Length;
            float currTextHeight = lineCount * 35f;
            float scrollHeight = _contentRectTransform.sizeDelta.y;
            float scrollPos = 1.15f - (currTextHeight / scrollHeight);
            string locution = string.Format("Height is: text {0}, scroll: {1}, scroll pos {2}", currTextHeight, scrollHeight, scrollPos);
            Debug.Log(locution);
            return scrollPos;
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
            _scrollRect.verticalNormalizedPosition = figureScrollPosition();
        }
    }
}
