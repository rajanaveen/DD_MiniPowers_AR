//Author: Asfiya Shaik

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour {

	public enum BlastType
	{
		fire,ice
	}

	public LayerMask layerMask;

	public void Blast(BlastType b_type)
	{
		Ray ray = Camera.main.ViewportPointToRay (new Vector3(.5f,.5f,0));
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit ,5f,layerMask))
		{
			EnemyController eController = hit.collider.GetComponent<EnemyController> ();
			if (eController != null) {
				eController.Death (b_type);
			}
		}
	}

	public void FireBlast()
	{
		Ray ray = Camera.main.ViewportPointToRay (new Vector3(.5f,.5f,0));
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit ,5f,layerMask))
		{
			EnemyController eController = hit.collider.GetComponent<EnemyController> ();
			if (eController != null) {
				eController.Death (BlastType.fire);
			}
		}
	}


	public void IceBlast()
	{
		Ray ray = Camera.main.ViewportPointToRay (new Vector3(.5f,.5f,0));
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit ,5f,layerMask))
		{
			EnemyController eController = hit.collider.GetComponent<EnemyController> ();
			if (eController != null) {
				eController.Death (BlastType.ice);
			}
		}
	}


}
