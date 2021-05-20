using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [HideInInspector]public bool playerInRange = false;
    private ContextClue CC;
    protected DialogueManager DM;

	protected virtual void Start()
	{
        CC = FindObjectOfType<ContextClue>();
        DM = FindObjectOfType<DialogueManager>();

    }

	private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            if (!DM.isInteracting)
            {
                Interact();
            }
        }
    }

    public virtual void Interact() {}
    
    //Two Collider2D Functions to trigger the Boolean when Entering and Existing.
    //triggered Bool Used within Update().
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("In Range");
            playerInRange = true;
            //CC.promptClue = playerInRange;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Out of Range");
            playerInRange = false;
            //CC.promptClue = playerInRange;
        }
    }
}
