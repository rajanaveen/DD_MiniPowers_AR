// Author : O.V.N Praveen

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	[SerializeField]
	private Animator animator;
	public float attackChangeInterval = 3f;
	const string attackBlendParameter="Attack_Style";
	const string deathParamter = "dead";
	bool dead = false;

	public GameObject fireEffect;
	public GameObject iceEffect;

	void Start()
	{
		StartCoroutine (AttackChangeCoroutine ());
	}

	void SetRandomAttack()
	{
		animator.SetFloat (attackBlendParameter, Random.Range (0, 6) * 1f);
	}

	IEnumerator AttackChangeCoroutine()
	{
		while (!dead) {
			SetRandomAttack ();
			yield return new WaitForSeconds (attackChangeInterval);
		}
	}

	public void Death(PlayerInputController.BlastType b_type)
	{
		if (!dead) {
			GetComponent<CapsuleCollider> ().enabled = false;
			EnemyManager.instance.currentEnemies--;
			dead = true;

			animator.SetTrigger (deathParamter);
			switch (b_type) {
			case PlayerInputController.BlastType.fire:
				fireEffect.SetActive (true);
				SoundManager.instance.PlayClip ("Fire_Effect_Sound");
				break;
			case PlayerInputController.BlastType.ice:
				iceEffect.SetActive (true);
				SoundManager.instance.PlayClip ("Ice_Effect_Sound");
				break;
			}
		}


	}
}
