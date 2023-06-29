using System.Collections;
using System.Collections.Generic;
using RPG.Equipment.Items;
using RPG.Equipment.Materials;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Stores
{
    public abstract class StorePanel : MonoBehaviour
    {
        [HideInInspector] public Item selectedItem;
        [HideInInspector] public string selectedItemDescriptionString;
        
        public GameObject ItemInStorePrefab;
        public GameObject ItemsListContent;
        
        [SerializeField] protected GameObject selectedItemIcon;
        [SerializeField] protected GameObject selectedItemDescription;
        [SerializeField] protected GameObject selectedItemCost;
        [SerializeField] protected GameObject selectedItemPanel;
        [SerializeField] protected GameObject playerGoldText;
        
        protected PlayerGold playerGold;
        
        private void Start()
        {
            playerGold = GameObject.FindGameObjectWithTag("GoldControler").GetComponent<PlayerGold>();
        }

        protected void Update()
        {
            playerGoldText.GetComponent<TMP_Text>().text = playerGold.gold.ToString();
        }

        protected void UpdateSelectedItemPanel(float costMultiplier)
        {
            if (selectedItem != null)
            {
                selectedItemPanel.SetActive(true);
                selectedItemIcon.GetComponent<Image>().sprite = selectedItem.itemSprite;
                selectedItemCost.GetComponent<TMP_Text>().text = ((int)(selectedItem.itemCost * costMultiplier)).ToString();
                selectedItemDescription.GetComponent<TMP_Text>().text = selectedItemDescriptionString;
            }
            else
            {
                selectedItemPanel.SetActive(false);
            }
        }
        
        public void ResetStorePanel()
        {
            selectedItem = null;
            for (int i = 0; i < ItemsListContent.transform.childCount; i++)
            {
                Destroy(ItemsListContent.transform.GetChild(i).gameObject);
            }
        }
        
        public void InitializePanel(List<Item> items)
        {

            ResetStorePanel();
            
            StoreControler storeControler = 
                GameObject.FindWithTag("StoreControler").GetComponent<StoreControler>();

            foreach (Item item in items)
            {
                if(item.itemName == "Empty") continue;
                var newItem = Instantiate(ItemInStorePrefab, ItemsListContent.transform);
                var newItemInStore = newItem.GetComponent<ItemInStore>();
                newItemInStore.item = item;
                newItemInStore.SetProperties();
            }
        }
        
        
    }   
}
