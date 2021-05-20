using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour
{
	private DialogueInteraction DI;
	public bool promptClue;
	public GameObject contextClue;
	private DialogueManager DM;
	//Edit.
	// Start is called before the first frame update
	public void Start()
	{
		contextClue.SetActive(false);
	}

	private void Update()
	{
		if (promptClue == true)
		{
			contextClue.SetActive(true);
		}
		else
		{
			contextClue.SetActive(false);
		}
	}
}
