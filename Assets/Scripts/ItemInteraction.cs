using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
	/*README---
	 * 
	 * Add this C# Script to Every GameObject. To add Dialogue/Sentences for the player to read out.
	 * 
	 * Dialogue Manger and ItemInteraction are important scripts.
	 * 
	 * Read Dialogue Manager Readme.
	 * 
	 */
	private DialogueManager DM;
	//If a collision has occured -> update trigger.
	private bool triggered = false;
	private bool canInteract;
	//Creating an array of strings used as Sentences within the Text Box.
	public string[] dialogueSentences;

	private void Start()
	{
		DM = FindObjectOfType<DialogueManager>();
	}

	private void Update()
	{
		if (triggered && Input.GetKeyUp(KeyCode.F)) 
		{
			canInteract = DM.canInteract;
			if (!DM.dialogActive && canInteract)
			{
				//Calls the functions within DialogueManager, then Gets the Dialogue or Sentences of this
				//	script within the GameObjectand passes it through the Dialogue Manager.
				DM.dialogSentences = dialogueSentences;
				DM.index = 0;
				DM.ShowDialogue();
			}
			triggered = false;
		}
	}

	//Two Collider2D Functions to trigger the Boolean when Entering and Existing.
	//triggered Bool Used within Update().
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			Debug.Log("In Range");
			triggered = true;
		}
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Out of Range");
            triggered = false;
        }
    }
}
