using RPG.Combat;
using System.Collections;
using UnityEngine;

namespace RPG.Controll
{
    public class Attack : MonoBehaviour, IAction

    {
        [SerializeField] private float timeBetweenAttacks = 3;
        [SerializeField] private bool continueAttacking = false;


        public GameObject damageArea;

        private float timeScienceLastAttack = Mathf.Infinity;
        private bool attacking = true;

        private void Update()
        {
            timeScienceLastAttack += Time.deltaTime;
        }

        public void PrefformAttack()
        {
            if (timeScienceLastAttack > timeBetweenAttacks)
            {
                GetComponent<Animator>().SetBool("Attack", true);
                timeScienceLastAttack = 0;
                StartCoroutine(CancelAttackAnimation());
            }
        }

        public void DealDamage()
        {
            damageArea.GetComponent<DamageDealer>().DealDamage();
        }

        public IEnumerator AttackContinouosly()
        {
            while (attacking)
            {
                PrefformAttack();
                yield return new WaitForSeconds(timeBetweenAttacks);
            }
        }

        public IEnumerator CancelAttackAnimation()
        {
            yield return new WaitForSeconds(0.5f);
            GetComponent<Animator>().SetBool("Attack", false);
        }

        public void Cancel()
        {
            GetComponent<Animator>().SetBool("Attack", false);
            attacking = false;
        }

        public void StartAction()
        {
            if (!continueAttacking)
            {
                PrefformAttack();
            }
            else
            {
                attacking = true;
                StartCoroutine(AttackContinouosly());
            }
        }
    }
}
