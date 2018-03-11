//Author: Asfiya
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityHealthManager : MonoBehaviour {

	public static CityHealthManager instance;

	int total_health = 600;
	int city_health= 600;
	float damageInterval=1f;
	int enemy_damage = 10;
    public Text status;

	void Start()
	{
		instance = this;
		city_health = total_health;
	}

	public float GetHealthSliderValue()
	{
		return (float)city_health / (float)total_health;
	}

	public IEnumerator Damage()
	{
		while (city_health > 0 && EnemyManager.instance.currentEnemies > 0) {
			city_health -= enemy_damage;

			yield return new WaitForSecondsRealtime (1f);
		}
		//Game End Code below
        if(city_health <= 0|| EnemyManager.instance.currentEnemies <= 0){

            if (city_health <= 0)
            {
                status.text = "City Destroyed";

            }
            else
            {
                status.text = "City Saved";
            }
            GameUIManager.instance.SwitchUIIndex(2);
        }
			


	}
}
