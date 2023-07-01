using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Equipment.Potions
{
    public class DropPotionStack : MonoBehaviour
    {
        [SerializeField] private GameObject potionStackGO;
        [SerializeField] private int chance;
        [SerializeField] private int amount = 1;

        public void SpawnPotionStack()
        {
            for (int i = 0; i < amount; i++)
            {
                if (Random.Range(1, 100) <= chance)
                {
                    var newPotionStack = Instantiate(potionStackGO);
                    newPotionStack.transform.position =
                        transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);   
                }   
            }
        }
    



    }

}