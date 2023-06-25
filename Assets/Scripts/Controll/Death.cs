using RPG.Combat;
using UnityEngine;

namespace RPG.Controll
{
    public class Death : MonoBehaviour, IAction
    {
        public void Cancel()
        {
            print("This action cannot be canceled");
        }

        public void StartAction()
        {
            GetComponent<Animator>().SetTrigger("Death");
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Health>().dead = true;
        }

    }
}
