using RPG.Combat;
using RPG.UI;
using UnityEngine;

namespace RPG.Controll
{
    public class PlayerControler : AbstractController
    {

        [SerializeField] private Camera mainCamera;
        
        Roll roll;
        private void Start()
        {
            roll = GetComponent<Roll>();
        }

        private void Update()
        {
            if(GetComponent<Health>().currentHealth == 0)
            {
                StartAction(GetComponent<Death>());
                return;
            }
            if (roll.rolling) return;
            if (Input.GetKeyDown(KeyCode.Space) && roll.timeSienceLastRoll > roll.rollCooldown)
            {
                StartAction(roll);
                return;
            }
            if (Input.GetMouseButton(0))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.transform.CompareTag("UI")) return;
                }
                StartAction(GetComponent<Attack>());
                return;
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            {
                StartAction(GetComponent<PlayerMovement>());
                return;
            }

            else if (currentAction != null)
            {
                currentAction.Cancel();
                currentAction = null;
            }


        }




    }
}
