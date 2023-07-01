using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Equipment.Items;
using UnityEditor.PackageManager;
using UnityEngine;

namespace RPG.UI
{
    public class EQCanvasControl : MonoBehaviour, ICloseableUIElement
    {
        [SerializeField] private BoxCollider eqCollider;
        [SerializeField] private GameObject itemMenu;
        private void Start()
        {
            GetComponent<Canvas>().enabled = false;
            eqCollider.enabled = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                EnablePanelOrDisablePanel();
            }

            if (itemMenu.activeSelf && Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.gameObject != itemMenu)
                    {
                        itemMenu.GetComponent<ItemMenu>().CloseItemChooseMenu();
                    }
                }
                else
                {
                    itemMenu.GetComponent<ItemMenu>().CloseItemChooseMenu();
                }  
            }
        }

        public void EnablePanelOrDisablePanel()
        {
            var canvas = GetComponent<Canvas>();
            if (canvas.enabled)
            {
                Close();
            }
            else
            {
                canvas.enabled = true;
                eqCollider.enabled = true;
                var items = transform.GetChild(0).GetChild(1).gameObject;
                for (int i = 0; i < items.transform.childCount; i++)
                {
                    var itemSlot = items.transform.GetChild(i).GetComponent<ItemSlot>();
                    if(!itemSlot) continue;
                    itemSlot.ActivateBoxCollider();
                }   
            }
        }

        public void Close()
        {
            var canvas = GetComponent<Canvas>();
            var items = transform.GetChild(0).GetChild(1).gameObject;
            for (int i = 0; i < items.transform.childCount; i++)
            {
                var itemSlot = items.transform.GetChild(i).GetComponent<ItemSlot>();
                if(!itemSlot) continue;
                itemSlot.DeactivateBoxCollider();
            }
            canvas.enabled = false;
            eqCollider.enabled = false;
        }
    }   
}
