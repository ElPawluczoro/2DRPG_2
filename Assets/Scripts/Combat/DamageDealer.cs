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

        private void Start()
        {
            damage = transform.parent.GetComponent<BasicStats>().attackDamage;
        }

        public void DealDamage()
        {
            if(targetToDamage != null)
            {
                foreach(GameObject target in targetToDamage)
                {
                    if (gameObject.transform.parent.CompareTag("Enemy") && target.CompareTag("Enemy")) continue;
                    target.GetComponent<Health>().GetDamage(damage);
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
