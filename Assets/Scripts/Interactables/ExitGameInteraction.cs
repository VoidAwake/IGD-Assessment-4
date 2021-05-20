using UnityEngine;

namespace DefaultNamespace
{
    public class ExitGameInteraction : Interactable
    {
        public override void Interact()
        {
            Application.Quit();
        }
    }
}