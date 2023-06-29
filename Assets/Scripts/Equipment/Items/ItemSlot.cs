using RPG.Combat;
using RPG.Stats.Player;
using RPG.UI;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Equipment.Items
{
    public class ItemSlot : MonoBehaviour
    {
        public Item itemInSlot;

        [SerializeField] private GameObject itemChooseMenuContent;
        [SerializeField] private GameObject itemChooseMenu;
        [SerializeField] private PlayerItems playerItems;
        [SerializeField] private MainUIItemsPanel mainUIItemsPanel;

        private ItemMenu itemMenu;

        private void Start()
        {
            if (!itemChooseMenu) return;
            itemMenu = itemChooseMenu.GetComponent<ItemMenu>();
        }

        public void ShowItemChooseMenu()
        {
            itemMenu.OpenItemChooseMenu(this);
        }

        private void Update()
        {
            if (!itemChooseMenu) return;
            if (itemChooseMenuContent.activeSelf && Input.GetKey(KeyCode.Escape))
            {
                itemMenu.CloseItemChooseMenu();
            }
        }

        public void CloseItemChooseMenu()
        {
            itemMenu.CloseItemChooseMenu();
        }

        public void OpenItemChooseMenu()
        {
            itemMenu.OpenItemChooseMenu(this);
        }

        public void UpdateItemStats()
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerStats>().UpdateStats();
            player.GetComponent<Health>().UpdateHealth();
        }
        
        public void EquipItem()
        {
            playerItems.playerEquipedItems.Add(itemInSlot);
        }

        public void UnequipItem()
        {
            if (itemInSlot != null)
            {
                playerItems.playerEquipedItems.Remove(itemInSlot);
            }
        }
        
        public void RemoveItemFromList()
        {
            if (itemInSlot.itemName != "Empty")
            {
                playerItems.playerBoughtItems.Remove(itemInSlot);
            }
        }

        public void PutBackItemOnTheList()
        {
            if (itemInSlot == null) return;
            if (itemInSlot.itemName != "Empty")
            {
                playerItems.playerBoughtItems.Add(itemInSlot);
            }
        }
        public void UpdateItemSlot()
        {
            GetComponent<Image>().sprite = itemInSlot.itemSprite;
        }

        public void UpdateItemsInSlot()
        {
            mainUIItemsPanel.UpdateItemsInSlot();
        }
    }   
}











