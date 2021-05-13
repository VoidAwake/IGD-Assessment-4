using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
	/*README---
	 * 
	 * This C# Script Manages all the dilogue in the game and controls all the elements within the Dialogue Box.
	 * Dialogue Manger and ItemInteraction are important scripts (Do Not Remove).
	 * Current Settings for this Test scene.
	 * - Game Display takes in Full HD 1920x1080
	 * - Canvas -> Canvas Scaler -> Reference Resolution = 1920x1080 (Scale With Screen Size)
	 * - Player GameObject has the Tag "Player"
	 * 
	 * Heirarchy path.
	 * - Canvas > DialogueManager > DialogueBox > Image,Text,ContinueBtn,CharacterImg.
	 *		- Dialogue Manager has the DialogueManager Script attached.
	 *		- DialogueBox is Active. Gets closed when the game starts.
	 *		- Text (TMP) has Padding: Left: 300, Right:40, Top: 30, Bottom: 30.
	 * 
	 * To Fix*******
	 * - Currently the dialogue can only be triggered once when it collides with the gameobject that has the ItemInteraction Script.
	 *	 The player will have to exit the collider zone and re-enter to trigger the dialogue again (Needs to be patched).
	 * - Additionally, the player avatar doesn't stop moving when interacting with the ItemInteraction Script GameObject.
	 * 
	 * Note*
	 * - Remove the Temporary Player movement script with something better.
	 * 
	 * Read ItemInteraction Readme and SoundManager.
	 */
	public GameObject dialogueBox;
	public GameObject optionBox;
	public TextMeshProUGUI textComponent;
	public GameObject ContinueBtn;
	public Image CharacterImg;
	//The speed at which the characters are typed in the text box.
	public float textSpeed;
	[HideInInspector] public int index;
	[HideInInspector] public bool dialogActive;
	[HideInInspector] public bool canInteract;

	//This string array gets the sentence/dialogue's from ItemInteraction when it gets called within the Update() function.
	[HideInInspector]public string[] dialogSentences;

	private void Start()
	{
		ContinueBtn.SetActive(false);
		textComponent.text = string.Empty;
		//Emptying and Disabling the Dialogue Box after 
		canInteract = true;
		dialogActive = false;
		dialogueBox.SetActive(false);
	}

	private void Update()
	{
		if (dialogActive && Input.GetKeyDown(KeyCode.F))
		{
			//If the Dialogue in the Text Box equals the current position within the dialogSentence[index],
			// it calls the NextSentence() function to go to the next index position within dialogSentence[index].
			if (textComponent.text == dialogSentences[index])
			{
				NextSentence();
			}
			else
			{
				//Stops the TypeWriting Effect.
				StopAllCoroutines();
				textComponent.text = dialogSentences[index];
				ContinueBtn.SetActive(true);
				SoundManager.PlaySound("Button");
			}
		}
	}

	public void ShowDialogue()
	{
		
		index = 0;
		dialogActive = true;
		dialogueBox.SetActive(true);
		gameObject.SetActive(true);
		StartCoroutine(typeWritterEffect());
	}

	IEnumerator typeWritterEffect()
	{
		yield return new WaitForSeconds(0.2f);
		textComponent.text = string.Empty;
		foreach (char c in dialogSentences[index].ToCharArray())
		{
			textComponent.text += c;
			SoundManager.PlaySound("Text");
			yield return new WaitForSeconds(Time.deltaTime * textSpeed);
		}
		ContinueBtn.SetActive(true);
		SoundManager.PlaySound("Button");
	}

	public void NextSentence()
	{
		ContinueBtn.SetActive(false);
		if (index < dialogSentences.Length - 1)
		{
			//increment through the dialogue.
			textComponent.text = string.Empty;
			StartCoroutine(typeWritterEffect());
			index++;
		}
		else
		{
			CloseDialogue();
			ContinueBtn.SetActive(false);
			gameObject.SetActive(false);
		}
	}

	public void CloseDialogue()
	{
		dialogueBox.SetActive(false);
		dialogActive = false;
		textComponent.text = string.Empty;
		canInteract = true;
	}
}
