using System.Collections;
using System.Collections.Generic;
using RPG.Equipment.Items;
using UnityEngine;

namespace RPG.UI
{
    public class ItemMenu : MonoBehaviour
    {
        [SerializeField] private PlayerItems playerItems;
        [SerializeField] private GameObject itemInMenuPrefab;
        public void CloseItemChooseMenu()
        {
            for (int i = 0; i < transform.GetChild(0).GetChild(0).childCount; i++)
            {
                Destroy(transform.GetChild(0).GetChild(0).transform.GetChild(i).gameObject);
            }
            gameObject.SetActive(false);
        }

        public void OpenItemChooseMenu(ItemSlot itemSlot)
        {
            
            if (transform.GetChild(0).GetChild(0).gameObject.activeSelf) CloseItemChooseMenu();
            var pI = playerItems.playerBoughtItems;
            gameObject.SetActive(true);
            var mainCamera = Camera.main;
            var xPos = mainCamera.ScreenToWorldPoint(Input.mousePosition).x;
            var yPos = mainCamera.ScreenToWorldPoint(Input.mousePosition).y;
            
            gameObject.transform.position = new Vector3(xPos + 1.2f, yPos + 1.4f, 0);
            foreach (var item in pI)
            {
                var newItem = Instantiate(itemInMenuPrefab, transform.GetChild(0).GetChild(0).transform);
                var itemInMenu = newItem.GetComponent<ItemInMenu>();
                itemInMenu.SetItemProperties(item);
                itemInMenu.activeItemSlot = itemSlot;
            }
        }
    }
}
