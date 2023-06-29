using System.Collections;
using System.Collections.Generic;
using RPG.UI;
using UnityEngine;

namespace RPG.Equipment.Items
{
    public class PlayerItems : MonoBehaviour
    {
        public List<Item> playerBoughtItems = new List<Item>();
        public List<Item> playerEquipedItems = new List<Item>();

        public int GetPlayerItemsAttackDamage()
        {
            var attackDamage = 0;
            foreach (var item in playerEquipedItems)
            {
                attackDamage += item.attackDamage;
            }

            return attackDamage;
        }
        
        public int GetPlayerItemsAbilityPower()
        {
            var abilityPower = 0;
            foreach (var item in playerEquipedItems)
            {
                abilityPower += item.abilityPower;
            }

            return abilityPower;
        }
        
        public int GetPlayerItemsHealthPoints()
        {
            var healthPoints = 0;
            foreach (var item in playerEquipedItems)
            {
                healthPoints += item.healthPoints;
            }

            return healthPoints;
        }
        
        public int GetPlayerItemsManaPoints()
        {
            var manaPoints = 0;
            foreach (var item in playerEquipedItems)
            {
                manaPoints += item.manaPoints;
            }

            return manaPoints;
        }

        public int GetPlayerItemsArmor()
        {
            var armor = 0;
            foreach (var item in playerEquipedItems)
            {
                armor += item.armor;
            }

            return armor;
        }
        
        public int GetPlayerItemsMagicResistance()
        {
            var magicResistance = 0;
            foreach (var item in playerEquipedItems)
            {
                magicResistance += item.magicResistance;
            }

            return magicResistance;
        }

        public void AddBoughtItem(Item item)
        {
            playerBoughtItems.Add(item);
        }
        



    }   
}
