using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Stats.Player
{
    [CreateAssetMenu(fileName = "ExpToLevelUp", menuName = "ExpInfoHolder")]
    public class EXPForLevels : ScriptableObject
    {
        public int[] expToLevelUp;
    }
}
