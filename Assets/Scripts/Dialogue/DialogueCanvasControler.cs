using System.Collections;
using System.Collections.Generic;
using RPG.UI;
using UnityEngine;

namespace RPG.Dialogue
{
    public class DialogueCanvasControler : MonoBehaviour, ICloseableUIElement
    {
        [SerializeField] private GameObject dialogues;

        public void OpenDialogueCanvas()
        {
            GameObject.FindGameObjectWithTag("CanvasManager").GetComponent<CanvasManager>().CloseAllWindows();
            gameObject.SetActive(true);
        }
        
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

        public void Close()
        {
            CloseDialogueCanvas();
        }
        
    }   
}
