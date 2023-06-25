using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RPG.Stats.Player
{
    public class PlayerEXP : MonoBehaviour
    {
        [SerializeField] private EXPForLevels expForLevels;

        public int playerLevel;
        public int playerXP;
        public int playerMaxXP;
        private int maxLevel;

        private void Start()
        {
            maxLevel = expForLevels.expToLevelUp.Count();
            playerLevel = 0;
            playerMaxXP = expForLevels.expToLevelUp[playerLevel];

        }

        public void GetXP(int xp)
        {
            if (maxLevel == playerLevel) return;
            playerXP += xp;
            if(playerXP >= expForLevels.expToLevelUp[playerLevel])
            {
                LevelUp();
            }

        }

        public void LevelUp()
        {
            if (maxLevel == playerLevel) return;
            playerXP -= expForLevels.expToLevelUp[playerLevel];
            playerLevel++;
            playerMaxXP = expForLevels.expToLevelUp[playerLevel];

        }




    }
}

