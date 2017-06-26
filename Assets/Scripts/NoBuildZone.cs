using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoBuildZone : MonoBehaviour {

    public bool cannotBuild;

	void OnTriggerStay(Collider other){
		
		if(other.gameObject != gameObject.transform.parent.gameObject && other.gameObject.tag != "Icon") {  

            cannotBuild = true;
            //Destroy(other.gameObject);
		} 
  
	}

    void OnTriggerExit(Collider other){
		
		if(other.gameObject != gameObject.transform.parent.gameObject && other.gameObject.tag != "Icon") {  

            cannotBuild = false;
		} 
	}
}
