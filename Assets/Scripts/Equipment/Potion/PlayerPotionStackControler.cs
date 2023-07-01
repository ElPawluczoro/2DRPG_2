using System;
using RPG.Equipment.Potions;
using UnityEngine;

namespace MyNamespace
{
    public class PlayerPotionStackControler : MonoBehaviour
    {
        private Potion potion;

        private void Start()
        {
            potion = GameObject.FindGameObjectWithTag("PotionHolder").GetComponent<Potion>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("PotionStack"))
            {
                potion.RestoreStacks(1);
                Destroy(other.gameObject);
            }
        }
    }
   
}