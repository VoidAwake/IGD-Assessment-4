using UnityEngine;

public class SceneChangeInteraction : Interactable
{
    [SerializeField] private int sceneBuildIndex;
    [SerializeField] private bool transition;

    private Camera mainCamera;

    protected override void Start()
    {
        base.Start();
        
        mainCamera = Camera.main;
    }

    public override void Interact()
    {
        mainCamera.GetComponent<SceneTransition>().ExitScene(sceneBuildIndex, transition);
    }
}
