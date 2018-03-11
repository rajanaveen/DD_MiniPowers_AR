// Author : Raja Srungavarapu

using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public static class CustomMethods
{

	public static void Shuffle<T> ( this IList<T> list)
	{
		int n = list.Count;
		System.Random rnd = new System.Random ();
		while(n>1)
		{
			int k = (rnd.Next (0, n) % n);
			n--;
			T value = list [k];
			list [k] = list [n];
			list [n] = value;
		}
	}
}

public class EnemyManager : MonoBehaviour {

	public List<Transform> enemies;
	public int totalEnemies;
	public static EnemyManager instance;
	public int currentEnemies;
	void Start()
	{
		instance = this;
		List<int> randomEnemies = new List<int> ();

		totalEnemies = Random.Range (15, 25);
		currentEnemies = totalEnemies;
		for (int i = 0; i < enemies.Count; i++) {
			randomEnemies.Add (i);
		}

		CustomMethods.Shuffle (randomEnemies);
		randomEnemies.RemoveRange (totalEnemies, enemies.Count - totalEnemies);
		for (int i = 0; i < totalEnemies; i++) {
			enemies [randomEnemies [i]].gameObject.SetActive (true);
		}
	}
}
