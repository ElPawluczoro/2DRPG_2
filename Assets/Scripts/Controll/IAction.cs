using UnityEngine;

namespace RPG.Controll
{
    public interface IAction 
    {
        public void StartAction();
        public void Cancel();
    }
}
