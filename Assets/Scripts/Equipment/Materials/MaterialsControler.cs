using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace RPG.Equipment.Materials
{
 public class MaterialsControler : MonoBehaviour
 {
     private List<GameObject> materials = new List<GameObject>();
 
     [SerializeField] private GameObject materialPoopUp;
     [SerializeField] private GameObject UICanvas;
 
     private GameObject player;
 
     private void Start()
     {
         player = GameObject.FindWithTag("Player");
         for (int i = 0; i < transform.childCount; i++)
         {
             materials.Add(transform.GetChild(i).gameObject);
         }
     }
 
     public void UpdateMaterials()
     {
         foreach (var material in materials)
         {
             material.GetComponent<MaterialGameObject>().SetMaterialProperties();
         }
     }
 
     private void Update()
     {
         UpdateMaterials();
     }
 
     public void AddMaterial(Material material, int quantity)
     {
         StartCoroutine(InstantiatePoopUp(material, quantity));
         foreach (var materialGO in materials)
         {
             if (materialGO.GetComponent<MaterialGameObject>().material.materialName == material.materialName)
             {
                 materialGO.GetComponent<MaterialGameObject>().AddMaterial(quantity);
             }
         }
     }
 
     private IEnumerator InstantiatePoopUp(Material material, int quantity)
     {
         var newPoopUp = Instantiate(materialPoopUp, UICanvas.transform);
         newPoopUp.transform.position =
             player.transform.position + new Vector3(Random.Range(0f, 0.5f), Random.Range(0f, 0.5f), 0);
         newPoopUp.transform.GetChild(0).GetComponent<Image>().sprite = material.materialSprite;
         newPoopUp.transform.GetChild(1).GetComponent<TMP_Text>().text = "+" + quantity;
         yield return new WaitForSeconds(1.5f);
         Destroy(newPoopUp);
         
         
     }
     
 
 }
}

















