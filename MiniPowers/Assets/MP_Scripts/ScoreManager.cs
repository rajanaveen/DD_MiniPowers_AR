//Author : O.V.N Praveen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Image health_slider_image;

	public Text enemies_text;

	void Update()
	{
		health_slider_image.fillAmount = CityHealthManager.instance.GetHealthSliderValue ();
		enemies_text.text = EnemyManager.instance.currentEnemies.ToString() + " / " + EnemyManager.instance.totalEnemies.ToString();
	}
}
