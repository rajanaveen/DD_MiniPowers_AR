//Author : Raja Srungavarapu
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour {
	public List<Transform> UI_Objects;

	public int currentUIIndex = 0;
	public static GameUIManager instance;

	void Start()
	{
		instance = this;
		SwitchUIIndex (0);
	}

	public void SwitchUIIndex(int index)
	{
		currentUIIndex = index;
		for (int i = 0; i < UI_Objects.Count; i++) {
			UI_Objects [i].gameObject.SetActive (i == currentUIIndex);
		}
	}

	public void RestartGame()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}


}
