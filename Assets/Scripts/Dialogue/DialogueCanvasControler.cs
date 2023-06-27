using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Dialogue
{
    public class DialogueCanvasControler : MonoBehaviour
    {
        [SerializeField] private GameObject dialogueCanvas;
        
        public void CloseDialogueCanvas()
        {
            gameObject.SetActive(false);
        }
    }   
}
