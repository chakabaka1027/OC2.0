using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public LayerMask blocks;

	float distance = 10;

	GameObject currentBlock;

	bool mouseDown = false;

//	// Update is called once per frame
	void Update () {

		//detect mouse input
		if(Input.GetMouseButton(0)){
			IdentifyBlock();
			mouseDown = true;
		} else {
			mouseDown = false;
			currentBlock = null;
		}

		//if you have selected a block
		if (currentBlock != null){
			DragBlock();
		}

	}

	void IdentifyBlock(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit, Mathf.Infinity, blocks) && !mouseDown){
			currentBlock = hit.collider.gameObject;
		}

	}

	void DragBlock(){

		currentBlock.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
		
	}


}
