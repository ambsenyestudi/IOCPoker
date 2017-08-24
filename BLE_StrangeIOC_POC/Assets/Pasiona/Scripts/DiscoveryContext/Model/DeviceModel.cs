using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Pasiona.Scripts.DiscoveryContext.Model
{
    public class DeviceModel
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public string GetPrettyName()
        {
            string name = Name;
            if (string.IsNullOrEmpty(name))
            {
                name = string.Format("Device ID({0})", ID);
            }
            return name;
        }
    }
}
