using RPG.Combat;
using RPG.Controll;
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

        [SerializeField] ProgressBar healthBar;
        [SerializeField] ProgressBar rollBar;



        private void Start()
        {
            health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
            roll = GameObject.FindGameObjectWithTag("Player").GetComponent<Roll>();
        }


        private void Update()
        {
            healthBar.GetValues(health.currentHealth, health.maxHealth);
            rollBar.GetValues(roll.timeSienceLastRoll, roll.rollCooldown);
        }




    }
}
