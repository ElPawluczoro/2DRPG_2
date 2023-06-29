using System.Collections;
using System.Collections.Generic;
using RPG.Stores;
using TMPro;
using UnityEngine;

namespace RPG.Dialogue
{
    public class DialogueButton : MonoBehaviour
    {
        public Dialogue dialogue;
        public Store store;
        public void Dialogue()
        {
            if (dialogue.openStore)
            {
                GameObject.FindGameObjectWithTag("StoreControler").GetComponent<StoreControler>().OpenStorePanel();
                store.InitializeStore();
                return;
            }
            
            GameObject.FindGameObjectWithTag("Dialogue").GetComponent<TMP_Text>().text =
                dialogue.npcText;
        }
    }   
}
