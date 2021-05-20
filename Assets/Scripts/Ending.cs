using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    [SerializeField] private int numberOfScenes;
    [SerializeField] private GameObject endingWall;
    [SerializeField] private int endingSceneBuildIndex;

    private bool dialogueTrigger = false;

    private void Start()
    {
        Debug.Log(PersistentData.OpenedScenes.Count);
        if (PersistentData.OpenedScenes.Count == numberOfScenes)
        {
            endingWall.SetActive(false);
            dialogueTrigger = true;
        }
    }
    
    private void Update()
    {
        if (dialogueTrigger)
        {
            dialogueTrigger = false;
            GetComponent<DialogueInteraction>().Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(endingSceneBuildIndex);
        }
    }
}
