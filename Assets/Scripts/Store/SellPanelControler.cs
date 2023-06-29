using System.Collections.Generic;
using RPG.Equipment.Items;
using RPG.Equipment.Materials;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Stores
{
    public class SellPanelControler : StorePanel
    {
        private float sellItemMultiplier = 0.6f;
        [HideInInspector] public GameObject selectedItemGO;

        private new void Update()
        {
            base.Update();
            UpdateSelectedItemPanel(sellItemMultiplier);
        }

        public void InitializeSellPanel()
        {
            List<Item> playerItems =
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItems>().playerBoughtItems;
            base.InitializePanel(playerItems);

        }

        public new void ResetStorePanel()
        {
            selectedItemGO = null;
            base.ResetStorePanel();
        }
        
        public void SellItem()
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItems>().playerBoughtItems
                .Remove(selectedItem);
            playerGold.gold += (int)(selectedItem.itemCost * sellItemMultiplier);
            Destroy(selectedItemGO);
            selectedItem = null;
            
        }

    }   
}
