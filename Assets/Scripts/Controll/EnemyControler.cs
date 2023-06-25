using RPG.Combat;
using UnityEngine;

namespace RPG.Controll
{
    public class EnemyControler : AbstractController
    {
        GameObject player;

        [SerializeField] private float chasingDistance = 5;
        [SerializeField] private float atackRange = 2;

        [SerializeField] float timeAfterAttack = 0.5f;
        float timeScienceAttack = Mathf.Infinity;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        private void Update()
        {
            timeScienceAttack += Time.deltaTime;
            if (player.GetComponent<Health>().dead)
            {
                if (currentAction != null) currentAction.Cancel();
                currentAction = null;
                return;
            }
            if(GetComponent<Health>().currentHealth == 0)
            {
                StartAction(GetComponent<Death>());
                return;
            }
            if (timeScienceAttack < timeAfterAttack) return;

            if (Vector3.Distance(player.transform.position, transform.position) < atackRange)
            {
                timeScienceAttack = 0;
                StartAction(GetComponent<Attack>());
                return;
            }

            if (Vector3.Distance(player.transform.position, transform.position) < chasingDistance)
            {
                StartAction(GetComponent<EnemyChaase>());
            }
            else
            {
                if(currentAction != null) currentAction.Cancel();
                currentAction = null;
            }



        }
    }
}