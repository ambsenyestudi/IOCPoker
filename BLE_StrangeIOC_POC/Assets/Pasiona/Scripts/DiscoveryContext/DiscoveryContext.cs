
using Assets.Pasiona.Scripts.DiscoveryContext.Controller.Commands;
using Assets.Pasiona.Scripts.DiscoveryContext.Controller.Events;
using Assets.Pasiona.Scripts.DiscoveryContext.Controller.StartupSequence;
using Assets.Pasiona.Scripts.DiscoveryContext.Service.Contracts;
using Assets.Pasiona.Scripts.DiscoveryContext.Service.Implementation;
using Assets.Pasiona.Scripts.DiscoveryContext.View;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;

namespace Assets.Pasiona.Scripts.DiscoveryContext
{
    public class DiscoveryContext : MVCSContext
    {
        public DiscoveryContext(MonoBehaviour view):base(view)
        {
        }
        public DiscoveryContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
        {

        }

        protected override void mapBindings()
        {
            
            //Models & Services
           
            injectionBinder.Bind<IBLE_Service>().To<BLE_Service>().ToSingleton();
            
            //ViewMediator
            mediationBinder.Bind<AppStatusView>().To<AppStatusMediator>();
            mediationBinder.Bind<ScanBtnView>().To<ScanBtnMediator>();
            mediationBinder.Bind<EventLogView>().To<EventLogMediator>();
            mediationBinder.Bind<AvailableDeviceListView>().To<AvailableDeviceListMediator>();
            mediationBinder.Bind<SelectedDeviceView>().To<SelectedDeviceMediator>();

            //StartCommand
            //commandBinder.Bind(ContextEvent.START).To<StartAppCommand>().To<StartGameCommand>().Once().InSequence();
            commandBinder.Bind(ContextEvent.START).To<StartAppCommand>().Once();
            
            //Event to Command
            commandBinder.Bind(BLE_Events.BLE_START_SCANNING).To<StartScanningCommand>();
            commandBinder.Bind(BLE_Events.BLE_STOP_SCANNING).To<StopScanningCommand>();
            commandBinder.Bind(ApplicationEvents.DEVICE_SELECTED).To<DeviceSelectedCommand>();

        }
    }
}
