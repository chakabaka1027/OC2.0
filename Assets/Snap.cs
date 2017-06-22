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
		transform.position = new Vector3(Mathf.Round(currentPos.x), Mathf.Round(currentPos.y), Mathf.Round(currentPos.z));	
	}
}
