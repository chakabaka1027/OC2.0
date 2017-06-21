using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

	float mouseSensitivity = .1f;
	float verticalLookRotation;
	float horizontalLookRotation;

	float verticalMovement;
	float horizontalMovement;


	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.lockState = CursorLockMode.None;


	}

	// Update is called once per frame
	void LateUpdate () {

		horizontalLookRotation += Input.GetAxis("Mouse X") * mouseSensitivity;
		horizontalLookRotation = Mathf.Clamp(horizontalLookRotation, -3.5f, 3.5f);

		verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivity;
		verticalLookRotation = Mathf.Clamp(verticalLookRotation, -3.5f, 3.5f);


		horizontalMovement += Input.GetAxis("Mouse X") * .05f;
		horizontalMovement = Mathf.Clamp(horizontalMovement, -3f, 3f);

		verticalMovement += Input.GetAxis("Mouse Y") * .05f;
		verticalMovement = Mathf.Clamp(verticalMovement, -2f, 2f);

		Camera.main.transform.localEulerAngles = new Vector3(verticalLookRotation, -horizontalLookRotation, 0);
		Camera.main.transform.localPosition = new Vector3(horizontalMovement, verticalMovement, -10);


	}
}
