//Author : Raja Srungavarapu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {

	public List<AudioClip> allClips;
	AudioSource audioSource;
	public static SoundManager instance;
	void Start()
	{
		instance = this;
		audioSource = GetComponent<AudioSource> ();
	}

	public void PlayClip(string clipName)
	{
		foreach (var clip in allClips) {
			if (clip.name == clipName) {
				audioSource.PlayOneShot (clip);
			}
		}
	}
}
