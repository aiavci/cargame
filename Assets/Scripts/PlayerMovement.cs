using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {
	public float moveSpeed;

	private Vector3 input; 

	/**
	 * Touch tools:
	 **/
	private Vector2 touchOrigin;
	int horizontal = 0;
	int vertical = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		//Non touch mode:
//		input = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
//		transform.position += input*moveSpeed;

		//Touch mode:
//		if (Input.touchCount > 0) {
//			Touch myTouch = Input.touches [0];
//			if (myTouch.phase == TouchPhase.Began) {
//				touchOrigin = myTouch.position;
//			} else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0) {
//				Vector2 touchEnd = myTouch.position;
//				float x = touchEnd.x - touchOrigin.x;
//				float y = touchEnd.y - touchOrigin.y;
//				touchOrigin.x = -1; 
//				if (Mathf.Abs (x) > Mathf.Abs (y)) {
//					horizontal = x > 0 ? 1 : -1;
//				} else {
//					vertical = y > 0 ? 1 : -1;
//				}
//			}
//		}
//		input = new Vector3 (horizontal, 0, vertical);
//		transform.position += input*moveSpeed;

		//Joystick mode:
		Vector3 input = new Vector3 (0, 0, CrossPlatformInputManager.GetAxis("Vertical"));
		float horizontalVelocity = CrossPlatformInputManager.GetAxis ("Horizontal");
		transform.Rotate(new Vector3(0, horizontalVelocity));
		transform.TransformDirection(Vector3.forward);
//		transform.position += input*moveSpeed;


		float v = CrossPlatformInputManager.GetAxis("Vertical") * moveSpeed;

		Vector3 FORWARD = transform.TransformDirection(Vector3.forward);

		transform.localPosition += FORWARD * v;
	}
}
