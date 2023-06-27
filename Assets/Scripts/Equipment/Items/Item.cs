using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Equipment.Items
{
    [CreateAssetMenu(fileName = "Item", menuName = "RPG/Item")]
    public class Item : ScriptableObject
    {
        public string itemName;
        public int itemCost;
        
        public int attackDamage;
        public int abilityPower;
        public int armor;
        public int magicResistance;
        public int healthPoints;
        public int manaPoints;

        public Sprite itemSprite;

    }   
}
