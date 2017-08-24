using strange.extensions.command.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Pasiona.Scripts.DiscoveryContext.Controller.Commands
{
    public class NoDeviceSelectedCommand : EventCommand
    {
        /*
         * TODO device selected service
        [Inject]
        public IBLE_Service BLE_Service { get; set; }
        */
        public override void Execute()
        {
            string message = "Nothing selected";
            
            Debug.Log(message);
        }
    }
}
