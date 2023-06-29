using System.Collections;
using System.Collections.Generic;
using RPG.Equipment.Items;
using Unity.VisualScripting;
using UnityEngine;

namespace RPG.UI
{
    public class MainUIItemsPanel : MonoBehaviour
    {
        [SerializeField] private List<ItemSlot> itemSlots;
        [SerializeField] private List<ItemSlot> itemSlotsToCompare;

        public void UpdateItemsInSlot()
        {
            for (int i = 0; i < itemSlots.Count; i++)
            {
                if (itemSlotsToCompare[i].itemInSlot == null) continue;
                if (itemSlotsToCompare[i].itemInSlot.name == "Empty") continue;
                itemSlots[i].itemInSlot = itemSlotsToCompare[i].itemInSlot;
                itemSlots[i].UpdateItemSlot();
            }
        }
    }   
}
