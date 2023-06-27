using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RPG.Dialogue
{
    public class PlayerDialogueControler : MonoBehaviour
    {
        [SerializeField] private GameObject dialogueCanvas;
        [SerializeField] private TMP_Text npcName;
        [SerializeField] private TMP_Text npcDialogueText;
        
        private bool npcInRange;
        private GameObject activeNPC;
        private void Update()
        {
            if (npcInRange && Input.GetKeyDown(KeyCode.E))
            {
                dialogueCanvas.SetActive(true);
                var dialogueController = activeNPC.GetComponent<NPCDialogueControler>();
                npcName.text = dialogueController.npcName + ":";
                npcDialogueText.text = dialogueController.welcomeMessage;
                activeNPC.GetComponent<NPCDialogueControler>().InitiateDialogues();
            }

            if (dialogueCanvas.activeSelf && !npcInRange)
            {
                dialogueCanvas.SetActive(false);
            }
            print(npcInRange);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("NPC"))
            {
                npcInRange = true;   
                other.transform.GetChild(0).gameObject.SetActive(true);
                activeNPC = other.gameObject;
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("NPC"))
            {
                npcInRange = false; 
                other.transform.GetChild(0).gameObject.SetActive(false);
                activeNPC = null;
            }
        }
    }
}




















