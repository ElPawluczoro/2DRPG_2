using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
using RPG.Equipment.Materials;
using RPG.Equipment.Potions;
using RPG.Stats.Enemy;
using UnityEngine;

namespace RPG.Controll
{
    public class Death : MonoBehaviour, IAction
    {
        public void Cancel()
        {
            print("This action cannot be canceled");
        }

        public void StartAction()
        {
            GetComponent<Animator>().SetTrigger("Death");
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Health>().dead = true;
            if (CompareTag("Enemy"))
            {
                var enemyXp = GetComponent<EnemyXP>();
                var materials = GetComponents<EnemyMaterials>();
                var enemyGold = GetComponent<EnemyGold>();
                var enemyPotionStack = GetComponent<DropPotionStack>();
                enemyXp.GiveXPForPlayer();
                enemyGold.GiveGoldForPlayer();
                foreach (EnemyMaterials material in materials)
                {
                    material.DropMaterial();  
                }
                enemyPotionStack.SpawnPotionStack();
                
                StartCoroutine(DestroyGameObjectAfterDeath());

            }
        }

        private IEnumerator DestroyGameObjectAfterDeath()
        {
            yield return new WaitForSeconds(5);
            Destroy(gameObject);
        }

    }
}
