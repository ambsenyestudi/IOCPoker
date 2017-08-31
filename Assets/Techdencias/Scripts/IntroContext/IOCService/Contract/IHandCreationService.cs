using Assets.Techdencias.Scripts.IntroContext.IOCModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Techdencias.Scripts.IntroContext.IOCService.Contract
{
    public interface IHandCreationService
    {
        GameObject CreateHand(string name, string firstCard, string secondCard, PlayerSeat playerSeat, int maxPlayers = 9);
    }
}
