using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public LayerMask blockLayer;
	public LayerMask iconLayer;

	public GameObject[] blocks;
	public Material[] blockColor;

	float mouseWheelValue;
	public bool isPlaceable;
	bool foundationPlaced;

	GameObject currentBlock;
	GameObject currentIcon;
	bool mouseDown = false;

	public GameObject blockContainer;

//	// Update is called once per frame
	void Update () {

		IdentifyIcon();

		//detect mousewheel
		if (Input.GetAxis("Mouse ScrollWheel") > 0){
			mouseWheelValue++;

			//increase icon scale
			if(mouseWheelValue > 6){
				IncreaseIconScale();
			}
		}
		if (Input.GetAxis("Mouse ScrollWheel") < 0){
			mouseWheelValue--;

			//decrease icon scale
			if(mouseWheelValue < -6){
				DecreaseIconScale();
			}
		}

		//detect mouse clicks
		if(Input.GetMouseButton(0)){
			IdentifyBlock();
			mouseDown = true;
		} else {

			if(currentBlock != null){
				
				if (blockContainer.transform.childCount >= 1 && currentBlock.transform.Find("Detector1").gameObject.GetComponent<Detector>().isColliding == false || currentBlock.transform.Find("Detector2").gameObject.GetComponent<Detector>().isColliding == false){
					Destroy(currentBlock);
				}
			}
			mouseDown = false;
			currentBlock = null;
		}

		//if you have selected a block
		if (currentBlock != null){
			DragBlock();
		}

		mouseWheelValue = Mathf.Clamp(mouseWheelValue, -6, 6);
	}

	void IdentifyBlock(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit, Mathf.Infinity, blockLayer) && !mouseDown){
			currentBlock = hit.collider.gameObject;
		}

	}

	void DragBlock(){
		currentBlock.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
	}


	void IdentifyIcon(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit, Mathf.Infinity, iconLayer)){
			currentIcon = hit.collider.gameObject;
			if(currentIcon != null && Input.GetMouseButtonDown(0)){
				if (currentIcon.transform.name == "Computer Icon"){
					CreateBlock(0, currentIcon);
				} else if (currentIcon.transform.name == "Art Icon"){
					CreateBlock(1, currentIcon);
				} else if (currentIcon.transform.name == "Exercise Icon"){
					CreateBlock(2, currentIcon);
				} else if (currentIcon.transform.name == "Game Icon"){
					CreateBlock(3, currentIcon);
				} else if (currentIcon.transform.name == "Music Icon"){
					CreateBlock(4, currentIcon);
				}
			}
		} else {
			currentIcon = null;
		}

	}

	void CreateBlock(int colorIndex, GameObject currentIcon){

		if (currentIcon.GetComponent<Icons>().size == Icons.Size.Small){
			GameObject block = Instantiate(blocks[0], Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Quaternion.identity) as GameObject;
			block.GetComponent<MeshRenderer>().material.color = blockColor[colorIndex].color;
			for(int i = 0; i < block.transform.childCount; i++){
				block.transform.GetChild(i).GetComponent<MeshRenderer>().material.color = blockColor[colorIndex].color;
			}
			block.transform.parent = blockContainer.transform;
		} else if (currentIcon.GetComponent<Icons>().size == Icons.Size.Medium){
			GameObject block = Instantiate(blocks[1], Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Quaternion.identity) as GameObject;
			block.GetComponent<MeshRenderer>().material.color = blockColor[colorIndex].color;
			for(int i = 0; i < block.transform.childCount; i++){
				block.transform.GetChild(i).GetComponent<MeshRenderer>().material.color = blockColor[colorIndex].color;
			}
			block.transform.parent = blockContainer.transform;
		} else if (currentIcon.GetComponent<Icons>().size == Icons.Size.Large){
			GameObject block = Instantiate(blocks[2], Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Quaternion.identity) as GameObject;
			block.GetComponent<MeshRenderer>().material.color = blockColor[colorIndex].color;
			for(int i = 0; i < block.transform.childCount; i++){
				block.transform.GetChild(i).GetComponent<MeshRenderer>().material.color = blockColor[colorIndex].color;
			}
			block.transform.parent = blockContainer.transform;
		}

	}

	void IncreaseIconScale(){
		if(currentIcon != null){
			mouseWheelValue = 0;
			currentIcon.GetComponent<Icons>().IncreaseScale();
		}
	}

	void DecreaseIconScale(){
		if(currentIcon != null){
			mouseWheelValue = 0;
			currentIcon.GetComponent<Icons>().DecreaseScale();
		}
	}


}
