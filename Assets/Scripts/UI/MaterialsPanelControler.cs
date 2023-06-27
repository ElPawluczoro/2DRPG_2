using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace RPG.UI
{
    public class MaterialsPanelControler : MonoBehaviour
    {
        [SerializeField] private BoxCollider materialsPanelCollider;

        private void Start()
        {
            GetComponent<Canvas>().enabled = false;
            materialsPanelCollider.enabled = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                EnableOrDisableMaterialsPanel();
            }
        }

        private void EnableOrDisableMaterialsPanel()
        {
            var canvas = GetComponent<Canvas>();
            canvas.enabled = !canvas.enabled;
            materialsPanelCollider.enabled = !materialsPanelCollider.enabled;
        }
        
        
    }   
}
