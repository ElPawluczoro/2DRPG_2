using UnityEngine;

namespace RPG.Controll
{

    public class EnemyChaase : MonoBehaviour, IAction
    {
        [SerializeField] private float speed = 2;
        GameObject player;
        bool chasing = false;


        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        private void Update()
        {
            if (!chasing) return;
            float playerX = player.transform.position.x;
            if (transform.position.x < playerX)
            {
                if (!(playerX - transform.position.x < 1) || Vector3.Distance(transform.position, player.transform.position) < 1)
                {
                    transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
            else if(transform.position.x > playerX)
            {
                if (!(transform.position.x - playerX < 1) || Vector3.Distance(transform.position, player.transform.position) < 1)
                {
                    transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
            }

            float playerY = player.transform.position.y;
            if (transform.position.y < playerY)
            {
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            }
            else if (transform.position.y > playerY)
            {
                transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
            }


        }

        public void Cancel()
        {
            chasing = false;
            GetComponent<Animator>().SetBool("Running", false);
        }

        public void StartAction()
        {
            chasing = true;
            GetComponent<Animator>().SetBool("Running", true);
        }




    }
}


