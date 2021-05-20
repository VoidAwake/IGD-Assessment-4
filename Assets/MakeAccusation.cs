using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MakeAccusation : MonoBehaviour
{
    [SerializeField] private Toggle neighbour1;
    [SerializeField] private Toggle neighbour2;
    [SerializeField] private Toggle neighbour3;
    [SerializeField] private Toggle neighbour4;

    [SerializeField] private Evidence win;
    [SerializeField] private Evidence notEnough;
    [SerializeField] private Evidence tooMuch;

    [SerializeField] private GameObject description;
    [SerializeField] private GameObject suspects;

    private DialogueInteraction dialogueInteraction;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(CheckAccusation);

        dialogueInteraction = GetComponent<DialogueInteraction>();
    }

    private void CheckAccusation()
    {
        if (!neighbour1.isOn && !neighbour2.isOn && neighbour3.isOn && neighbour4.isOn)
        {
            dialogueInteraction.evidence = win;
        } else if (neighbour3.isOn && neighbour4.isOn)
        {
            dialogueInteraction.evidence = tooMuch;
        }
        else
        {
            dialogueInteraction.evidence = notEnough;
        }
        
        dialogueInteraction.Interact();
        
        description.SetActive(false);
        suspects.SetActive(false);
        gameObject.SetActive(false);
    }
}
