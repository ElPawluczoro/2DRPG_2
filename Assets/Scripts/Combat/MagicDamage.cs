using System.Collections;
using System.Collections.Generic;
using RPG.Stats;
using RPG.Stats.Player;
using UnityEngine;

namespace RPG.Combat
{
    public class MagicDamage : MonoBehaviour, Damage
    {
        public void DealDamage(int amount, GameObject target)
        {
            BasicStats targetStats;
            targetStats = target.GetComponent<BasicStats>();

            float damageReduction = targetStats.magicResistance * 0.01f;
            int damage = amount - (int)(amount * damageReduction);
            target.GetComponent<Health>().GetDamage(damage);
            print(damage);
            
        }
    }
}
