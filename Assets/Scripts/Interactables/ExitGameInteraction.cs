using UnityEngine;

namespace DefaultNamespace
{
    public class ExitGameInteraction : Interactable
    {
        protected override void Interact()
        {
            Application.Quit();
        }
    }
}