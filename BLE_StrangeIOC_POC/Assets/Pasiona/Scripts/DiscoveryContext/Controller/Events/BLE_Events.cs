using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Pasiona.Scripts.DiscoveryContext.Controller.Events
{
    public class BLE_Events
    {
        public const string BLE_READY = "BLE_READY";
        public const string BLE_START_SCANNING = "BLE_START_SCANNING";
        public const string BLE_STARTED_SCANNING = "BLE_STARTED_SCANNING";
        public const string BLE_STOP_SCANNING = "BLE_STOP_SCANNING";
        public const string BLE_STOPPED_SCANNING = "BLE_STOPPED_SCANNING";
        public const string BLE_DEVICE_DISCOVERED = "BLE_DEVICE_DISCOVERED";
        public const string BLE_DEVICE_AVAILABLE_FOR_CONNECTION = "BLE_DEVICE_AVAILABLE_FOR_CONNECTION";
        public const string BLE_NO_DEVICE_FOR_CONNECTION = "BLE_NO_DEVICE_FOR_CONNECTION";
        public const string BLE_TRYING_TO_ESTABLISH_CONNECTION = "BLE_TRYING_TO_ESTABLISH_CONNECTION";
        public const string BLE_CONNECTION_ESTABLISHED = "BLE_CONNECTION_ESTABLISHED";
        public const string BLE_CONNECTION_STATE_UPDATE = "BLE_CONNECTION_STATE_UPDATE";
        public const string BLE_DEVICE_DISCONNECTED = "BLE_DEVICE_DISCONNECTED";
        public const string BLE_ERROR = "BLE_ERROR";
        public const string BLE_UPDATED = "BLE_UPDATED";
    }
}
