using System;
using System.Collections.Generic;
using RPG.Stats;
using UnityEngine;

namespace RPG.Combat
{
    public class DamageDealer : MonoBehaviour
    {
        public int damage;
        public List<GameObject> targetToDamage = new List<GameObject>();

        private Damage damageType;
        private BasicStats basicStats;

        public GameObject damageGO;

        private void Start()
        {
            basicStats = transform.parent.GetComponent<BasicStats>();
            damageType = damageGO.GetComponent<Damage>();
        }

        private void Update()
        {
            damage = basicStats.attackDamage;
        }

        public void DealDamage()
        {
            if(targetToDamage != null)
            {
                foreach(GameObject target in targetToDamage)
                {
                    if (gameObject.transform.parent.CompareTag("Enemy") && target.CompareTag("Enemy")) continue;
                    //target.GetComponent<Health>().GetDamage(damage);
                    damageType.DealDamage(damage, target);
                }
            }
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            targetToDamage.Add(collision.gameObject);
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            targetToDamage.Remove(collision.gameObject);
        }

    }
}
