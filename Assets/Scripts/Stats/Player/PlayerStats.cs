using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Equipment.Items;
using UnityEngine;

namespace RPG.Stats.Player
{
    public class PlayerStats : BasicStats
    {
        public int basicAttackDamage;
        public int basicAbilityPower;
        public int basicHealthPoints;
        public int basicManaPoints;
        public int basicArmor;
        public int basicMagicResistance;

        private void Start()
        {
            //UpdateStats();
        }

        private void Awake()
        {
            UpdateStats();
        }

        public void UpdateStats()
        {
            PlayerItems playerItems = GetComponent<PlayerItems>();

            attackDamage = basicAttackDamage + playerItems.GetPlayerItemsAttackDamage();
            abilityPower = basicAbilityPower + playerItems.GetPlayerItemsAbilityPower();
            armor = basicArmor + playerItems.GetPlayerItemsArmor();
            magicResistance = basicMagicResistance + playerItems.GetPlayerItemsMagicResistance();
            healthPoints = basicHealthPoints + playerItems.GetPlayerItemsHealthPoints();
            manaPoints = basicManaPoints + playerItems.GetPlayerItemsManaPoints();
        }
        
        
    }
    
}
