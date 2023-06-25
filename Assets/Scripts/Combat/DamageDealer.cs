using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class DamageDealer : MonoBehaviour
    {
        public int damage = 3;
        //public GameObject DamageArea;
        public List<GameObject> targetToDamage = new List<GameObject>();
        public void DealDamage()
        {
            if(targetToDamage != null)
            {
                foreach(GameObject target in targetToDamage)
                {
                    if (gameObject.transform.parent.tag == "Enemy" && target.tag == "Enemy") continue;
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
