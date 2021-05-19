using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour
{
	private Interactable item;
	public bool promptClue;
	public GameObject contextClue;
	//Edit.
	// Start is called before the first frame update
	public void Start()
	{
		contextClue.SetActive(false);
		item = FindObjectOfType<Interactable>();
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
