using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected bool playerInRange = false;
    private ContextClue cC;

    private void Start()
    {
        cC = FindObjectOfType<ContextClue>();
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }
    }

    protected virtual void Interact() {}
    
    //Two Collider2D Functions to trigger the Boolean when Entering and Existing.
    //triggered Bool Used within Update().
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("In Range");
            playerInRange = true;
            //cC.promptClue = playerInRange;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Out of Range");
            playerInRange = false;
            //cC.promptClue = playerInRange;
        }
    }
}
