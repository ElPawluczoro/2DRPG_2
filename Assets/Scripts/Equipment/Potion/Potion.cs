using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Equipment.Potions
{
    public class Potion : MonoBehaviour
    {
        [SerializeField] private PotionStats potion;

        private int potionPower;
        [SerializeField] private int maxPotionStacks;
        [SerializeField] private int potionStacks;

        private Health playerHealth;
        private Image potionImage;

        private void Start()
        {
            if (potion.potionType == PotionType.HEALTH_POTION)
            {
                playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();   
            }

            potionImage = GetComponent<Image>();

            SetPotionProperties();
            potionStacks = maxPotionStacks;
            UpdatePotionSprite();

        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Q))
            {
                UsePotion();
            }
        }


        private void SetPotionProperties()
        {
            potionPower = potion.potionPower;
            maxPotionStacks = potion.potionStacks;
            
        }

        public void UsePotion()
        {
            if (potionStacks < maxPotionStacks) return;
            if (Math.Abs(playerHealth.currentHealth - playerHealth.maxHealth) < 0.01f) return;
            playerHealth.RestoreHealth(potionPower);
            potionStacks = 0;
            UpdatePotionSprite();
        }

        private void UpdatePotionSprite()
        {
            if (potionStacks == maxPotionStacks)
            {
                potionImage.sprite = potion.potionSprite;
            }
            else
            {
                potionImage.sprite = potion.emptyPotionSprite;
            }
        }

        public void RestoreStacks(int amount)
        {
            potionStacks += amount;
            {
                if (potionStacks > maxPotionStacks)
                {
                    potionStacks = maxPotionStacks;
                }
            }
            UpdatePotionSprite();
        }
        
        
        
    }   
}
