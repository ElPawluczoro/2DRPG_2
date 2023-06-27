using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaterials : MonoBehaviour
{
    public RPG.Equipment.Materials.Material materialHeld;
    public float chanceToDrop;
    public int minQuantity;
    public int maxQuantity;

    public void DropMaterial()
    {
        var chance = Random.Range(1, 100);
        if (chance <= chanceToDrop)
        {
            GameObject.FindGameObjectWithTag("MaterialControler").GetComponent<MaterialsControler>().AddMaterial(materialHeld, Random.Range(minQuantity, maxQuantity));
        }
    }

}
