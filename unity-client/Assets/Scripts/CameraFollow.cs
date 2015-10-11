using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject ball;
	private Vector3 cam_height = new Vector3 (0f, 10f, -5f);
	
	void LateUpdate () {
		transform.position = ball.transform.position + cam_height;
	}
}
