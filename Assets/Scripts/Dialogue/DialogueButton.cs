using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RPG.Dialogue
{
    public class DialogueButton : MonoBehaviour
    {
        public Dialogue dialogue;
        public void Dialogue()
        {
            GameObject.FindGameObjectWithTag("Dialogue").GetComponent<TMP_Text>().text =
                dialogue.npcText;
        }
    }   
}
