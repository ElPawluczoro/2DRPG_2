using System;
using System.Collections;
using System.Collections.Generic;
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
            canvas.enabled = !canvas.enabled;
            eqCollider.enabled = !eqCollider.enabled;
        }

        public void Close()
        {
            var canvas = GetComponent<Canvas>();
            canvas.enabled = false;
            eqCollider.enabled = false;
        }
    }   
}
