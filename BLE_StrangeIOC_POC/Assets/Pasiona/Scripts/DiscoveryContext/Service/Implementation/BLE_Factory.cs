using Assets.Pasiona.Scripts.DiscoveryContext.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using startechplus.ble;
using UnityEngine;

namespace Assets.Pasiona.Scripts.DiscoveryContext.Service.Implementation
{
    public class BLE_Factory : IBLE_Factory
    {
        private IBleBridge _defaultBleBridge = null;

        public IBleBridge DefaultBleBridge
        {
            get
            {
                if(_defaultBleBridge == null)
                {
                    _defaultBleBridge = Get();
                }
                return _defaultBleBridge;
            }
        }


        public IBleBridge Get()
        {
            IBleBridge bleBridge;
            switch (Application.platform)
            {
                case RuntimePlatform.Android:
                    bleBridge = new AndroidBleBridge();
                    break;
                case RuntimePlatform.IPhonePlayer:
                    bleBridge = new iOSBleBridge();
                    break;
                default:
                    bleBridge = new DummyBleBridge();
                    break;
            }
            return bleBridge;

        }
    }
}
