using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Equipment.Materials
{
    public class PlayerGold : MonoBehaviour
    {
        public int gold;

        public void AddGold(int amount)
        {
            gold += amount;
        }

        public void SpendGold(int amount)
        {
            gold -= amount;
        }

        public bool IsGoldEnough(int valueToCompare)
        {
            return valueToCompare <= gold;
        }


    }
}