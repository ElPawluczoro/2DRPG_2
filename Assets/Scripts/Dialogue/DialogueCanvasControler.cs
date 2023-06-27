using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Dialogue
{
    public class DialogueCanvasControler : MonoBehaviour
    {
        [SerializeField] private GameObject dialogueCanvas;
        [SerializeField] private GameObject dialogues;
        
        
        public void CloseDialogueCanvas()
        {
            ResetDialogues();
            gameObject.SetActive(false);
        }

        public void ResetDialogues()
        {
            for (int i = 0; i < dialogues.transform.childCount; i++)
            {
                Destroy(dialogues.transform.GetChild(i).gameObject);
            }
        }
        
    }   
}
