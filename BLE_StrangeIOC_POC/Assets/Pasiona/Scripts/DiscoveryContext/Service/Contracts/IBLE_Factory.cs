using startechplus.ble;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Pasiona.Scripts.DiscoveryContext.Service.Contracts
{
    public interface IBLE_Factory
    {
        IBleBridge DefaultBleBridge { get; }
        IBleBridge Get();
    }
}
