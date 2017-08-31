using strange.extensions.context.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Techdencias.Scripts.IntroContext
{
    public class IntroRoot : ContextView
    {
        void Awake()
        {
            //Instantiate the context, passing it this instance.
            context = new IntroContext(this);
        }
    }
}
