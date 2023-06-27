using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace RPG.Equipment.Materials
{
    [CreateAssetMenu(fileName = "Material", menuName = "RPG/Material")]
    public class Material : ScriptableObject
    {
        public string materialName;
        public Sprite materialSprite;
    }   
}
