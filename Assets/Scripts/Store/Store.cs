using System.Collections;
using System.Collections.Generic;
using RPG.Equipment.Items;
using UnityEngine;

namespace RPG.Stores
{
    public class Store : MonoBehaviour
    {
        [SerializeField] private List<Item> itemsInStore;

        /*public void InitializeStore()
        {
            StoreControler storeControler = GameObject.FindWithTag("StoreControler").GetComponent<StoreControler>();

            storeControler.BuyPanelButton();
            
            foreach (Item item in itemsInStore)
            {
                var newItemInStore = 
                    Instantiate(storeControler.buyPanelControlerScript.ItemInStorePrefab, storeControler.buyPanelControlerScript.ItemsListContent.transform);
                var itemInStore = newItemInStore.GetComponent<ItemInStore>();
                itemInStore.item = item;
                itemInStore.SetProperties();
            }
        }*/

        public void InitializeStore()
        {
            StoreControler storeControler = GameObject.FindWithTag("StoreControler").GetComponent<StoreControler>();
            storeControler.buyPanelControlerScript.InitializeStore(itemsInStore);
        }

    }
    
}
