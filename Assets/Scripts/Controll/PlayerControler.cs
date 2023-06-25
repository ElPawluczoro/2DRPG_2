using RPG.Combat;
using UnityEngine;

namespace RPG.Controll
{
    public class PlayerControler : AbstractController
    {
/*        private IAction currentAction;
        public void StartAction(IAction action)
        {
            if (currentAction == action) return;
            if (currentAction != null)
            {
                currentAction.Cancel();
            }
            currentAction = action;
            currentAction.StartAction();
        }*/

        private void Update()
        {

            if(GetComponent<Health>().currentHealth == 0)
            {
                StartAction(GetComponent<Death>());
                return;
            }

            if (Input.GetMouseButton(0))
            {
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
