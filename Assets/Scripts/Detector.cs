using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour {

	public bool isColliding;

	void OnCollisionEnter(Collision col){
		
		isColliding = true;
	}

	void OnCollisionExit(Collision col){
		//isColliding = false;
	}

}
