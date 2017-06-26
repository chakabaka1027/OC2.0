using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour {

	public bool isColliding = false;

	void OnTriggerStay(Collider other){
		
		if(other.gameObject != gameObject.transform.parent.gameObject && other.gameObject.tag != "Icon") {  
			isColliding = true;
		} 
  
	}

    void OnTriggerExit(Collider col){
		
		if(col.gameObject != gameObject.transform.parent.gameObject) {  
			isColliding = false;
		} 
	}

}
