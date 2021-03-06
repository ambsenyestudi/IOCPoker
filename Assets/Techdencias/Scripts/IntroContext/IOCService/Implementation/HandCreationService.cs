﻿using Assets.Techdencias.Scripts.IntroContext.IOCModel.Enums;
using Assets.Techdencias.Scripts.IntroContext.IOCService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Techdencias.Scripts.IntroContext.IOCService.Implementation
{
    public class HandCreationService : IHandCreationService
    {
        public GameObject CreateHand(string name, string firstCard, string secondCard, PlayerSeat playerSeat, int maxPlayers = 9)
        {
            GameObject hand = createCards(name, firstCard, secondCard);
            float alpha = 0f;
            float dirLenght = 0f;
            //ToDo figure out elliptical rotation
            switch (maxPlayers)
            {
                default:
                    float angle = 360f / (maxPlayers + 1);
                    //The closer to 90 smaller set, the coloser to 0 bigger setp
                    alpha = angle * ((int)(playerSeat) + 1);
                    if (alpha > 0 && alpha < 37)
                    {
                        Debug.Log("First angel = " + alpha + " " + (alpha + (angle / 9)));
                        alpha += angle / 1.75f;
                        dirLenght = 7.5f;
                    }
                    else if (alpha > 37 && alpha < 110)
                    {
                        float offset = 2 * angle / 3;
                        if (alpha < 90)
                        {
                            alpha += offset;
                        }
                        else
                        {
                            alpha -= offset;
                        }
                        dirLenght = 9f;
                    }
                    else 
                    {
                        
                        if (alpha > 110 && alpha < 180)
                        {
                            //alpha -= 4 * angle / 5;
                            Debug.Log("Last angel = " + alpha + " " + (alpha -(angle / 9)));
                            alpha -= angle / 1.75f;
                            dirLenght = 7.5f;
                        }
                        
                    }
                    break;
            }
            
            Vector3 seatPos = Quaternion.AngleAxis(alpha, Vector3.forward) * Vector3.up;
            seatPos *= dirLenght;

            hand.transform.localPosition = seatPos;
            return hand;
        }
        private GameObject createSingleCard(string spriteName, Transform parent)
        {
            var cardSprite = UnityEngine.Object.Instantiate(Resources.Load(spriteName)) as GameObject;
            cardSprite.transform.parent = parent.transform;
            cardSprite.transform.localScale = Vector3.one;
            cardSprite.transform.localPosition = Vector3.zero;
            cardSprite.transform.localRotation = Quaternion.identity;
            return cardSprite as GameObject;
        }
        private GameObject createCards(string name, string firstSprite, string secondSprite)
        {
            GameObject hand = new GameObject();
            hand.name = name;
            hand.transform.localPosition = new Vector3(0f, 0f, 0f);
            GameObject leftCard = new GameObject();
            leftCard.name = "leftCard";
            leftCard.transform.parent = hand.transform;
            leftCard.transform.localPosition = new Vector3(-0.3f, 0f, 0f);
            var leftCardSprite = createSingleCard(firstSprite, leftCard.transform);

            GameObject rightCard = new GameObject();
            rightCard.name = "rightCard";
            rightCard.transform.parent = hand.transform;
            rightCard.transform.localPosition = new Vector3(0.3f, 0f, 0f);
            var rightCardSprite = createSingleCard(secondSprite, rightCard.transform);

            return hand;
        }
    }
}
