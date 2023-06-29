using RPG.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Equipment.Items
{
    public class ItemInMenu : MonoBehaviour
    {
        [SerializeField] private GameObject itemImage;
        [SerializeField] private TMP_Text itemName;
        [SerializeField] private Item item;

        public ItemSlot activeItemSlot;
        
        public void SetItemProperties(Item item)
        {
            itemImage.GetComponent<Image>().sprite = item.itemSprite;
            itemName.text = item.itemName;
            this.item = item;
        }

        public void ChooseItem()
        {
            activeItemSlot.PutBackItemOnTheList();
            activeItemSlot.UnequipItem();
            activeItemSlot.itemInSlot = item;
            activeItemSlot.UpdateItemSlot();
            activeItemSlot.RemoveItemFromList();
            activeItemSlot.EquipItem();
            activeItemSlot.CloseItemChooseMenu();

            activeItemSlot.UpdateItemStats();
            
            activeItemSlot.UpdateItemsInSlot();
        }
        
        
        
        
        
        
    }   
}
