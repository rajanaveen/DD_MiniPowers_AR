//Author: Raja Srungavarapu
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

	public class ARHitScript : MonoBehaviour
	{
		public Transform m_HitTransform;
		public float maxRayDistance = 30.0f;
		public LayerMask collisionLayer = 1 << 10;  //ARKitPlane layer
		public bool created = true;
		public GameObject character;

	public void SetCreated(bool b)
	{
		created = b;

	}
        bool HitTestWithResultType (ARPoint point, ARHitTestResultType resultTypes)
        {
            List<ARHitTestResult> hitResults = UnityARSessionNativeInterface.GetARSessionNativeInterface ().HitTest (point, resultTypes);
            if (hitResults.Count > 0) {
				character.SetActive (true);
                foreach (var hitResult in hitResults) {
                    Debug.Log ("Got hit!");
                    m_HitTransform.position = UnityARMatrixOps.GetPosition (hitResult.worldTransform);
                    m_HitTransform.rotation = UnityARMatrixOps.GetRotation (hitResult.worldTransform);
                    Debug.Log (string.Format ("x:{0:0.######} y:{1:0.######} z:{2:0.######}", m_HitTransform.position.x, m_HitTransform.position.y, m_HitTransform.position.z));
					created = true;
					StartCoroutine(CityHealthManager.instance.Damage ());
					return true;
                }
            }
            return false;
        }
		
		void Update () {
			#if UNITY_EDITOR  
			if (Input.GetMouseButtonDown (0)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				
				if (Physics.Raycast (ray, out hit, maxRayDistance, collisionLayer)) {
					m_HitTransform.position = hit.point;
					m_HitTransform.rotation = hit.transform.rotation;
				}
			}
			#else
			if (Input.touchCount > 0 && m_HitTransform != null)
			{
				var touch = Input.GetTouch(0);
				if ((touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved) && !created)
				{
					var screenPosition = Camera.main.ScreenToViewportPoint(touch.position);
					ARPoint point = new ARPoint {
						x = screenPosition.x,
						y = screenPosition.y
					};

                    ARHitTestResultType[] resultTypes = {
                        ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent, 
                        ARHitTestResultType.ARHitTestResultTypeHorizontalPlane, 
                        ARHitTestResultType.ARHitTestResultTypeFeaturePoint
                    }; 
					
                    foreach (ARHitTestResultType resultType in resultTypes)
                    {
                        if (HitTestWithResultType (point, resultType))
                        {
                            return;
                        }
                    }
				}
			}
			#endif

		}

	
	}

