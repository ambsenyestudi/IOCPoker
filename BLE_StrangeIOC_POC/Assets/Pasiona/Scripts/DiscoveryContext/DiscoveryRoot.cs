using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Pasiona.Scripts.DiscoveryContext
{
    public class DiscoveryRoot : ContextView
    {

        void Awake()
        {
            //Instantiate the context, passing it this instance.
            context = new DiscoveryContext(this);
        }
    }
}
