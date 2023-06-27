using UnityEngine;

namespace RPG.Controll
{
    public class PlayerMovement : MonoBehaviour, IAction
    {
        [SerializeField] private float speed = 2;

        private bool canMove = true;

        public void Cancel()
        {
            canMove = false;
            GetComponent<Animator>().SetBool("Running", false);
        }

        private void Update()
        {
            if (!canMove) return;

            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

        public void StartAction()
        {
            canMove = true;
            GetComponent<Animator>().SetBool("Running", true);
        }

    }

}