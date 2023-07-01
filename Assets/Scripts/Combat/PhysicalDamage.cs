using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Stats;
using RPG.Stats.Player;
using UnityEngine;

namespace RPG.Combat
{ 
    public class PhysicalDamage : MonoBehaviour, Damage
    {
        public void DealDamage(int amount, GameObject target)
        {
            BasicStats targetStats;
            if (target.transform.CompareTag("Player")) targetStats = target.GetComponent<PlayerStats>();
            else targetStats = target.GetComponent<BasicStats>();

            float damageReduction = targetStats.armor * 0.01f;
            int damage = amount - (int)(amount * damageReduction);
            target.GetComponent<Health>().GetDamage(damage);

        }
    }
}
