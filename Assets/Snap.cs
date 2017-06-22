using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPos = transform.position;

		if(transform.name == "Block Small(Clone)"){
			transform.position = new Vector3(Mathf.Round(currentPos.x*2)/2, Mathf.Round(currentPos.y), Mathf.Round(currentPos.z));	
		}
		if(transform.name == "Block Medium(Clone)"){
			transform.position = new Vector3(Mathf.Round(currentPos.x*2)/2, Mathf.Round(currentPos.y), Mathf.Round(currentPos.z));	
		}
		if(transform.name == "Block Large(Clone)"){
			transform.position = new Vector3(Mathf.Round(currentPos.x*2)/2, Mathf.Round(currentPos.y), Mathf.Round(currentPos.z));	
		}
	}
}
