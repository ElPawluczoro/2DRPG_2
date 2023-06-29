using System.Collections;
using System.Collections.Generic;
using RPG.Stores;
using TMPro;
using UnityEngine;

namespace RPG.Dialogue
{
    public class NPCDialogueControler : MonoBehaviour
    {
        public string npcName;
        [TextArea(15,20)]
        public string welcomeMessage;

        public GameObject dialoguePrefab;
        public Dialogue[] dialogues;

        public void InitiateDialogues()
        {
            foreach (Dialogue dialogue in dialogues)
            {
                var newDialogue = Instantiate(dialoguePrefab, GameObject.FindGameObjectWithTag("DialogueControler").transform);
                newDialogue.transform.GetChild(0).GetComponent<TMP_Text>().text = dialogue.playerText;
                var dialogueButton = newDialogue.GetComponent<DialogueButton>();
                dialogueButton.dialogue = dialogue;
                if (dialogue.openStore)
                {
                    dialogueButton.store = GetComponent<Store>();
                }
            }
        }



    }   
}
