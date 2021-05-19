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
	

	private NotebookController notebook;

	[SerializeField] protected Evidence evidence;

	protected bool isInteracting;

	protected override void Start()
	{
		base.Start();
		
		notebook = FindObjectOfType<NotebookController>();
	}

	protected override void Interact() {
		//Calls the functions within DialogueManager, then Gets the Dialogue or Sentences of this
		//	script within the GameObjectand passes it through the Dialogue Manager.
		string[] sentences = evidence.dialogue.Split(new string[] { "\n" }, StringSplitOptions.None);
		DM.ShowDialogue(sentences, evidence.speakerSprite);
		notebook.AddEvidence(evidence);
		DM.isInteracting = true;
		Debug.Log("new interaction");
	}
}
