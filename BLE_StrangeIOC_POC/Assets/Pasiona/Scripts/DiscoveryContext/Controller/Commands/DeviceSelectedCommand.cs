using Assets.Pasiona.Scripts.DiscoveryContext.Model;
using strange.extensions.command.impl;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;

namespace Assets.Pasiona.Scripts.DiscoveryContext.Controller.Commands
{
    public class DeviceSelectedCommand : EventCommand
    {
        /*
         * TODO device selected service
        [Inject]
        public IBLE_Service BLE_Service { get; set; }
        */
        public override void Execute()
        {
            DeviceModel model = evt.data as DeviceModel;
            string message = "New model Selected: ";
            if(model == null)
            {
                message += "was null";
            }
            else
            {
                message += model.GetPrettyName();
            }
            Debug.Log(message);
        }
    }
}
