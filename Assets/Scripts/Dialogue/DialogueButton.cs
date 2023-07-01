using System.Collections;
using System.Collections.Generic;
using RPG.Alchemist;
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
            if (dialogue.opens == Opens.STORE)
            {
                GameObject.FindGameObjectWithTag("StoreControler").GetComponent<StoreControler>().OpenStorePanel();
                store.InitializeStore();
                return;
            }
            else if (dialogue.opens == Opens.ALCHEMIST)
            {
                GameObject.FindGameObjectWithTag("AlchemistPanel").GetComponent<AlchemistControler>().Open();
                return;
            }
            
            GameObject.FindGameObjectWithTag("Dialogue").GetComponent<TMP_Text>().text =
                dialogue.npcText;
        }
    }   
}
