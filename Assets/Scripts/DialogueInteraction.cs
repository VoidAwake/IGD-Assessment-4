using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : Interactable
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

	private bool canInteract;
	//Creating an array of strings used as Sentences within the Text Box.
	public string[] dialogueSentences;

	private void Start()
	{
		DM = FindObjectOfType<DialogueManager>();
	}

	protected override void Interact() {
		canInteract = DM.canInteract;
		if (!DM.dialogActive && canInteract)
		{
			//Calls the functions within DialogueManager, then Gets the Dialogue or Sentences of this
			//	script within the GameObjectand passes it through the Dialogue Manager.
			DM.dialogSentences = dialogueSentences;
			DM.index = 0;
			DM.ShowDialogue();
		}
		playerInRange = false;
	}
}
