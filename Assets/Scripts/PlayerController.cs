using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public LayerMask blocks;
	public LayerMask icons;

	float scaleValue;

	GameObject currentBlock;
	GameObject currentIcon;
	bool mouseDown = false;

//	// Update is called once per frame
	void Update () {

		IdentifyIcon();

		//detect mousewheel
		if (Input.GetAxis("Mouse ScrollWheel") > 0){
			scaleValue++;

			if(scaleValue > 6){
				IncreaseIconScale();
			}
		}
		if (Input.GetAxis("Mouse ScrollWheel") < 0){
			scaleValue--;

			if(scaleValue < -6){
				DecreaseIconScale();
			}
		}

		//detect mouse clicks
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

		scaleValue = Mathf.Clamp(scaleValue, -6, 6);


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


	void IdentifyIcon(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit, Mathf.Infinity, icons)){
			currentIcon = hit.collider.gameObject;
		} else {
			currentIcon = null;
		}

	}

	void IncreaseIconScale(){
		if(currentIcon != null){
			currentIcon.transform.localScale *= 1.75f;
			scaleValue = 0;
		}
	}

	void DecreaseIconScale(){
		if(currentIcon != null){
			currentIcon.transform.localScale /= 1.75f;
			scaleValue = 0;
		}
	}


}
