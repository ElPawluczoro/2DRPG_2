using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RPG.Equipment.Materials
{
    public class EnemyGold : MonoBehaviour
    {
        [HideInInspector] public int goldGiven;

        public int minGold;
        public int maxGold;

        private void Start()
        {
            goldGiven = Random.Range(minGold, maxGold);
        }

        public void GiveGoldForPlayer()
        {
            GameObject.FindGameObjectWithTag("GoldControler").GetComponent<PlayerGold>().AddGold(goldGiven);
        }

    }   
}
