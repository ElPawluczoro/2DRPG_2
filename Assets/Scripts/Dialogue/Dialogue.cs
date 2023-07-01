using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Dialogue
{
    [CreateAssetMenu(fileName = "Dialogue", menuName = "RPG/Dialogue")]
    public class Dialogue : ScriptableObject
    {
        public string playerText;
        public string npcText;
        public Opens opens = Opens.NOTHING;
    }

    public enum Opens
    {
        NOTHING, STORE, ALCHEMIST
    }
    
}
