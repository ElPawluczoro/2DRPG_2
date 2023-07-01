using RPG.Combat;
using RPG.Controll;
using RPG.Stats.Player;
using System.Collections;
using System.Collections.Generic;
using RPG.Equipment.Items;
using RPG.Stats;
using TMPro;
using UnityEngine;
using Material = RPG.Equipment.Materials.Material;

namespace RPG.UI
{
    public class UIControler : MonoBehaviour
    {
        private Health health;
        private Roll roll;
        private PlayerEXP playerEXP;
        private BasicStats stats;

        [SerializeField] private ProgressBar healthBar;
        [SerializeField] private ProgressBar rollBar;
        [SerializeField] private ProgressBar xpBar;

        [SerializeField] private TMP_Text adText;
        [SerializeField] private TMP_Text apText;
        [SerializeField] private TMP_Text armorText;
        [SerializeField] private TMP_Text magicResistanceText;

        [SerializeField] TMP_Text levelText;

        public GameObject itemTooltip;

    

        private void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            health = player.GetComponent<Health>();
            roll = player.GetComponent<Roll>();
            playerEXP = player.GetComponent<PlayerEXP>();
            stats = player.GetComponent<BasicStats>();
        }


        private void Update()
        {
            healthBar.GetValues(health.currentHealth, health.maxHealth);
            rollBar.GetValues(roll.timeSienceLastRoll, roll.rollCooldown);
            xpBar.GetValues(playerEXP.playerXP, playerEXP.playerMaxXP);
            levelText.text = playerEXP.playerLevel.ToString();

            adText.text = stats.attackDamage.ToString();
            apText.text = stats.abilityPower.ToString();
            armorText.text = stats.armor.ToString();
            magicResistanceText.text = stats.magicResistance.ToString();

            var mousePosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var itemSlot = hit.transform.gameObject.GetComponent<ItemSlot>();
                if (itemSlot != null)
                {
                    itemSlot.ShowItemTooltip(mousePosition);
                }
                else
                {
                    itemTooltip.SetActive(false);
                }
            }
            else
            {
                itemTooltip.SetActive(false);
            }


        }

    }
}
