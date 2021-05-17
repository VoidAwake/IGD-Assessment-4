using System;
using DefaultNamespace;
using UnityEngine;

public class DialogueInteraction : Interactable
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

	private NotebookController notebook;

	[SerializeField] private Evidence evidence;

	private bool canInteract;

	private void Start()
	{
		DM = FindObjectOfType<DialogueManager>();
		notebook = FindObjectOfType<NotebookController>();
	}

	protected override void Interact() {
		if (!DM.dialogActive)
		{
			//Calls the functions within DialogueManager, then Gets the Dialogue or Sentences of this
			//	script within the GameObjectand passes it through the Dialogue Manager.
			string[] sentences = evidence.dialogue.Split(new string[] { "\n" }, StringSplitOptions.None);
			DM.ShowDialogue(sentences, evidence.speakerSprite);
			notebook.AddEvidence(evidence);
		}
		//playerInRange = false;
	}
}
