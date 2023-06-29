using System.Collections;
using System.Collections.Generic;
using RPG.Equipment.Items;
using RPG.Equipment.Materials;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Stores
{
    public class BuyPanelControler : StorePanel
    {

        private new void Update()
        {
            base.Update();
            UpdateSelectedItemPanel(1);
        }
        
        public void InitializeStore(List<Item> items)
        {
            GameObject.FindWithTag("StoreControler").GetComponent<StoreControler>().BuyPanelButton();
            base.InitializePanel(items);
        }
        
        public new void ResetStorePanel()
        {
            selectedItemPanel.SetActive(false);
            base.ResetStorePanel();
        }
        
        public void BuyItem()
        {
            PlayerItems playerItems = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItems>();

            if (selectedItem.itemCost <= playerGold.gold)
            {
                playerGold.SpendGold(selectedItem.itemCost);
                playerItems.AddBoughtItem(selectedItem);
            }
            
        }
        
    }
    
}
