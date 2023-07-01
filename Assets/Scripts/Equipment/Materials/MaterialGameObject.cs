using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Equipment.Materials
{
    public class MaterialGameObject : MonoBehaviour
    {
        public int quantity;
        public Material material;

        public void SetMaterialProperties()
        {
            transform.GetChild(0).GetComponent<TMP_Text>().text = material.materialName;
            transform.GetChild(1).GetComponent<TMP_Text>().text = quantity.ToString();
            transform.GetChild(2).GetComponent<Image>().sprite = material.materialSprite;
        }

        public void AddMaterial(int q)
        {
            quantity += q;
        }

        public void SpendMaterial(int q)
        {
            quantity -= q;
        }
        
    }   
}
