using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour {

	public bool isColliding;

	void OnTriggerStay(Collider col){
		
		if (col.gameObject != gameObject.transform.parent){  
			isColliding = true;
		}
	}

}
