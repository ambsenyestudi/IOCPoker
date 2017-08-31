using Assets.Techdencias.Scripts.IntroContext.IOCController.IOCCommand;
using Assets.Techdencias.Scripts.IntroContext.IOCService.Contract;
using Assets.Techdencias.Scripts.IntroContext.IOCService.Implementation;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Techdencias.Scripts.IntroContext
{
    public class IntroContext : MVCSContext
    {
        public IntroContext(MonoBehaviour view) : base(view)
        {

        }
        public IntroContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
        {

        }
        protected override void mapBindings()
        {
            injectionBinder.Bind<IHandCreationService>().To<HandCreationService>();
            commandBinder.Bind(ContextEvent.START).To<StartAppCommand>().Once();
        }
    }
}
