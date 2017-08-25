using Assets.Pasiona.Scripts.DiscoveryContext.Service.Contracts;
using strange.extensions.command.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Pasiona.Scripts.DiscoveryContext.Controller.Commands
{
    public class StopScanningCommand : EventCommand
    {
        [Inject]
        public IDiscovery_Service BLE_Service { get; set; }
        public override void Execute()
        {
            BLE_Service.StopScanning();
        }
    }
}
