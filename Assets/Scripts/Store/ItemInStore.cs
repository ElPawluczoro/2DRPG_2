using System.Collections;
using System.Collections.Generic;
using RPG.Equipment.Items;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Stores
{
    public class ItemInStore : MonoBehaviour
    {
        public Item item;

        public void SetProperties()
        {
            string itemDescription = GetItemDescription();
            transform.GetChild(0).GetComponent<Image>().sprite = item.itemSprite;
            transform.GetChild(1).GetComponent<TMP_Text>().text = itemDescription;
        }

        private string GetItemDescription()
        {
            string itemDescription= "";
            if (item.attackDamage != 0) itemDescription += "Attack damage: " + item.attackDamage + "\n";
            if (item.abilityPower != 0) itemDescription += "Ability power: " + item.abilityPower + "\n";
            if (item.armor != 0) itemDescription += "Armor: " + item.armor + "\n";
            if (item.magicResistance != 0) itemDescription += "Magic resistance: " + item.magicResistance + "\n";
            if (item.healthPoints != 0) itemDescription += "Health points: " + item.healthPoints + "\n";
            if (item.manaPoints != 0) itemDescription += "Mana: " + item.manaPoints + "\n";
            return itemDescription;
        }

        public void SelectItemInStore()
        {            
            var storeControler = GameObject.FindGameObjectWithTag("StoreControler").GetComponent<StoreControler>();
            if (storeControler.GetComponent<StoreControler>().buyPanel.activeSelf)
            {
                storeControler.buyPanelControlerScript.selectedItem = item;
                storeControler.buyPanelControlerScript.selectedItemDescriptionString = GetItemDescription();   
            }
            else
            {
                storeControler.sellPanelControlerScript.selectedItem = item;
                storeControler.sellPanelControlerScript.selectedItemDescriptionString = GetItemDescription();
                storeControler.sellPanelControlerScript.selectedItemGO = gameObject;

            }
        }
        

    }   
}
