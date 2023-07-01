using System;
using RPG.Equipment.Materials;
using RPG.Equipment.Potions;
using RPG.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Material = RPG.Equipment.Materials.Material;

namespace RPG.Alchemist
{
    public class AlchemistControler : MonoBehaviour, ICloseableUIElement
    {
        private Potion potionControler;
        private PotionStats potion;
        private PlayerGold playerGold;
        private MaterialsControler materialsControler;

        [SerializeField] private Material glassesOfWine;
        
        [SerializeField] private Image currentPotionImage;
        [SerializeField] private TMP_Text currentPotionDescription;

        [SerializeField] private TMP_Text upgradeCostGoldText;
        [SerializeField] private TMP_Text upgradeCostGlassesText;
        
        [SerializeField] private Image nextPotionImage;
        [SerializeField] private TMP_Text nextPotionDescription;

        private void Start()
        {
            potionControler = GameObject.FindGameObjectWithTag("PotionHolder").GetComponent<Potion>();
            potion = potionControler.potion;
            playerGold = 
                GameObject.FindGameObjectWithTag("GoldControler").GetComponent<PlayerGold>();
            materialsControler =
                GameObject.FindGameObjectWithTag("MaterialControler").GetComponent<MaterialsControler>();
        }
        public void Close()
        {
            GetComponent<Canvas>().enabled = false;
            transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
        }

        public void Open()
        {
            GameObject.FindWithTag("CanvasManager").GetComponent<CanvasManager>().CloseAllWindows();
            GetComponent<Canvas>().enabled = true;
            transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
            SetPanelProperties();
        }

        public void UpgradePotion()
        {
            if (potion.maxLevel) return;
            if (!playerGold.IsGoldEnough(potion.upgradeGoldCost) ||
                !materialsControler.IsMaterialEnough(glassesOfWine, potion.upgradeGlassesOfWineCost)) return;
            playerGold.SpendGold(potion.upgradeGoldCost);
            materialsControler.SpendMaterial(glassesOfWine, potion.upgradeGlassesOfWineCost);
            potionControler.SetPotion(potion.nextLevelPotion);
            potion = potionControler.potion;
            potionControler.UpdatePotion();
            SetPanelProperties();
        }

        public void SetPanelProperties()
        {
            currentPotionImage.sprite = potion.potionSprite;
            currentPotionDescription.text = potion.potionName + "\n" +
                                            "Potion power: " + potion.potionPower + "\n" +
                                            "Potion max stacks: " + potion.potionStacks;

            upgradeCostGoldText.text = potion.upgradeGoldCost.ToString();
            upgradeCostGlassesText.text = potion.upgradeGlassesOfWineCost.ToString();

            if (potion.maxLevel)
            {
                nextPotionImage.enabled = false;
                nextPotionDescription.text = "MAX";
            }
            else
            {
                PotionStats nextPotion = potion.nextLevelPotion;
                nextPotionImage.sprite = nextPotion.potionSprite;
                nextPotionDescription.text = nextPotion.potionName + "\n" +
                                             "Potion power: " + nextPotion.potionPower + "\n" +
                                             "Potion max stacks: " + nextPotion.potionStacks;   
            }
        }
        
        
        
    }
   
}