using UnityEngine;

namespace RPG.Controll
{
    public abstract class AbstractController : MonoBehaviour
    {
        protected IAction currentAction;
        public void StartAction(IAction action)
        {
            if (currentAction == action) return;
            if (currentAction != null)
            {
                currentAction.Cancel();
            }
            currentAction = action;
            currentAction.StartAction();
        }

    }

}