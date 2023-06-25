using RPG.Combat;
using RPG.Controll;
using RPG.Stats.Player;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RPG.UI
{
    public class UIControler : MonoBehaviour
    {
        private Health health;
        private Roll roll;
        private PlayerEXP playerEXP;

        [SerializeField] ProgressBar healthBar;
        [SerializeField] ProgressBar rollBar;
        [SerializeField] ProgressBar xpBar;

        [SerializeField] TMP_Text levelText;



        private void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            health = player.GetComponent<Health>();
            roll = player.GetComponent<Roll>();
            playerEXP = player.GetComponent<PlayerEXP>();
        }


        private void Update()
        {
            healthBar.GetValues(health.currentHealth, health.maxHealth);
            rollBar.GetValues(roll.timeSienceLastRoll, roll.rollCooldown);
            xpBar.GetValues(playerEXP.playerXP, playerEXP.playerMaxXP);
            levelText.text = playerEXP.playerLevel.ToString();
        }




    }
}
