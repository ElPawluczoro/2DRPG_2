using RPG.Stats.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Stats.Enemy
{
    public class EnemyXP : MonoBehaviour
    {
        public int enemyXP = 5;

        public void GiveXPForPlayer()
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEXP>().GetXP(enemyXP);
        }


    }
}
