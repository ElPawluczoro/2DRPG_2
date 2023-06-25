using System.Collections;
using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        public int currentHealth;
        public int maxHealth = 5;
        public bool dead = false;

        private void Start()
        {
            currentHealth = maxHealth;
        }

        public void GetDamage(int damage)
        {
            if (currentHealth == 0) return;
            if (currentHealth >= damage) currentHealth -= damage;
            else currentHealth = 0;
            StartCoroutine(ChangeColour());
        }

        public IEnumerator ChangeColour()
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(0.5f);
            GetComponent<SpriteRenderer>().color = Color.white;
        }

    }
}
