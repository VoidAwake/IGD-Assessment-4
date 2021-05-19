namespace DefaultNamespace
{
    public class DefaultInteraction : DialogueInteraction
    {
        protected override void Start()
        {
            if (!PersistentData.TutorialDialogues.Contains(evidence))
            {
                base.Start();

                Interact();
                
                PersistentData.TutorialDialogues.Add((evidence));
            }
        }
    }
}