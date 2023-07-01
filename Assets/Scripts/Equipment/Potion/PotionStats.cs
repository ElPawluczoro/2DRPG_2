using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Equipment.Potions
{
    [CreateAssetMenu(fileName = "Potion", menuName = "RPG/Potion")]
    public class PotionStats : ScriptableObject
    {
        public string potionName;
        public Sprite potionSprite;
        public Sprite emptyPotionSprite;
        public PotionType potionType;
        public int potionPower;
        public int potionStacks;
    }

    public enum PotionType
    {
        HEALTH_POTION, MANA_POTION
    }
}

