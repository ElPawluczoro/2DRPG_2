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

        private ItemMenu itemMenu;

        private void Start()
        {
            itemMenu = itemChooseMenu.GetComponent<ItemMenu>();
        }

        public void ShowItemChooseMenu()
        {
            itemMenu.OpenItemChooseMenu(this);
        }

        private void Update()
        {
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
        
        /*public void CloseItemChooseMenu()
        {
            for (int i = 0; i < itemChooseMenuContent.transform.childCount; i++)
            {
                Destroy(itemChooseMenuContent.transform.GetChild(i).gameObject);
            }
            itemChooseMenu.SetActive(false);
        }

        public void OpenItemChooseMenu()
        {
            
            if (itemChooseMenuContent.activeSelf) CloseItemChooseMenu();
            var pI = playerItems.playerBoughtItems;
            itemChooseMenu.SetActive(true);
            var xPos = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            var yPos = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
            
            itemChooseMenu.transform.position = new Vector3(xPos + 1.2f, yPos + 1.4f, 0);
            for (int i = 0; i < pI.Count; i++)
            {
                var newItem = Instantiate(itemInMenuPrefab, itemChooseMenuContent.transform);
                var itemInMenu = newItem.GetComponent<ItemInMenu>();
                itemInMenu.SetItemProperties(pI[i]);
                itemInMenu.activeItemSlot = this;
            }
        }*/

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
    }   
}











