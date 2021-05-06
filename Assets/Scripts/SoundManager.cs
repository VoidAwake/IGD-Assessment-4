using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	/*
	 * The AudioClips were sources from Freesounds.org
	 * 
	 * This script manages the audio currently used in the canvas.
	 * 
	 */
    static AudioSource audSource;
    public static AudioClip TextSound, ContinueBtnSound;

	private void Start()
	{
		TextSound = Resources.Load<AudioClip>("typeWriter");
		ContinueBtnSound = Resources.Load<AudioClip>("BtnSound");

		audSource = GetComponent<AudioSource>();
		audSource.volume = 0.7f;
	}

	public static void PlaySound (string clip)
	{
		switch (clip)
		{
			case "Text":
				audSource.PlayOneShot(TextSound);
				break;
			case "Button":
				audSource.PlayOneShot(ContinueBtnSound);
				break;
		}
	}
}
