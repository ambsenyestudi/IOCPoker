using Assets.Techdencias.Scripts.IntroContext.IOCModel.Enums;
using Assets.Techdencias.Scripts.IntroContext.IOCService.Contract;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Techdencias.Scripts.IntroContext.IOCController.IOCCommand
{
    public class StartAppCommand : Command
    {
        [Inject(ContextKeys.CONTEXT_VIEW)]
        public GameObject ContextView { get; set; }

        [Inject(ContextKeys.CONTEXT)]
        public IContext context { get; set; }

        [Inject]
        public IHandCreationService CreationService { get; set; }

        public override void Execute()
        {
            GameObject playerOneHand = CreationService.CreateHand("Player_1", "AC", "JC", PlayerSeat.Seat1);
            playerOneHand.transform.parent = ContextView.transform;
            GameObject playerTwoHand = CreationService.CreateHand("Player_2", "AS", "JS", PlayerSeat.Seat2);
            playerTwoHand.transform.parent = ContextView.transform;
            GameObject playerThreeHand = CreationService.CreateHand("Player_3", "QC", "KC", PlayerSeat.Seat3);
            playerThreeHand.transform.parent = ContextView.transform;
            GameObject playerFourHand = CreationService.CreateHand("Player_4", "QS", "KS", PlayerSeat.Seat4);
            playerFourHand.transform.parent = ContextView.transform;

        }
    }
}
