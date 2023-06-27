using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RPG.Equipment.Materials
{
    public class GoldControler : MonoBehaviour
    {
        [SerializeField] private TMP_Text goldText;
        [SerializeField] private PlayerGold playerGold;
        private void Update()
        {
            goldText.text = playerGold.gold.ToString();
        }
    }
   
}