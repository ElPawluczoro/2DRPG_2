using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace RPG.Equipment.Potions
{
    [CreateAssetMenu(fileName = "Potion", menuName = "RPG/Potion")]
    public class PotionStats : ScriptableObject
    {
        public string potionName;
        public Sprite potionSprite;
        public Sprite emptyPotionSprite;
        public PotionType potionType;
        public int potionPower;
        public int potionStacks;

        public int upgradeGoldCost;
        public int upgradeGlassesOfWineCost;
        public PotionStats nextLevelPotion;

        public bool maxLevel;
    }

    public enum PotionType
    {
        HEALTH_POTION, MANA_POTION
    }

    [CustomEditor(typeof(PotionStats)), CanEditMultipleObjects]
    public class PotionStatsEditor : Editor
    {
        private List<boolStruct> structList;

        private void OnEnable()
        {
            structList = new List<boolStruct>();
            SetBooleans();
        }

        private void SetBooleans()
        {
            HideIf("maxLevel", false, "nextLevelPotion");
            HideIf("maxLevel", false, "upgradeGoldCost");
            HideIf("maxLevel", false, "upgradeGlassesOfWineCost");
        }

        private void HideIf(string boolName, bool boolValue, string fieldName)
        {
            boolStruct _boolStruct = new boolStruct()
            {
                targetBoolName = boolName,
                targetBoolValue = boolValue,
                targetVarName = fieldName,
            };
            structList.Add(_boolStruct);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            var obj = serializedObject.GetIterator();
            if (obj.NextVisible(true))
            {
                do
                {
                    bool visible = true;
                    foreach (var i in structList)
                    {
                        if (i.targetVarName == obj.name)
                        {
                            FieldInfo boolName = target.GetType().GetField(i.targetBoolName);
                            var boolValue = boolName.GetValue(target);
                            if (boolValue.ToString() != i.targetBoolValue.ToString())
                                visible = false;
                            else
                            {
                                visible = true;
                                break;
                            }
                        }
                    }

                    if (visible) EditorGUILayout.PropertyField(obj, true);
                }
                while (obj.NextVisible(false));
            }

            serializedObject.ApplyModifiedProperties();
        }

        private struct boolStruct
        {
            public string targetBoolName { get; set; }
            public bool targetBoolValue { get; set; }
            public string targetVarName { get; set; }
        }
        
    }
    
    
}



















