using RPG.Combat;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RPG.UI
{
    public class ProgressBar : MonoBehaviour
    {
        public float maxValue;
        public float value;

        [SerializeField] private GameObject bar;
        [SerializeField] private TMP_Text barText;

        private void Update()
        {
            if (barText != null) barText.text = (int)value + "/" + (int)maxValue;
            if (value == 0)
            {
                bar.transform.localScale = new Vector3(0, 1, 1);
                return;
            }
            if(value/maxValue > 1)
            {
                bar.transform.localScale = new Vector3(1, 1, 1);
                return;
            }
            bar.transform.localScale = new Vector3(value / maxValue, 1, 1);
        }

        public void GetValues(float value, float maxValue)
        {
            this.value = value;
            this.maxValue = maxValue;
        }

    }
}
