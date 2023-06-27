using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.UI
{
    public class EQCanvasControl : MonoBehaviour
    {
        [SerializeField] private BoxCollider eqCollider;
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
        }

        public void EnablePanelOrDisablePanel()
        {
            var canvas = GetComponent<Canvas>();
            canvas.enabled = !canvas.enabled;
            eqCollider.enabled = !eqCollider.enabled;
        }
    }   
}
