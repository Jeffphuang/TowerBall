using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject ball;
	public Vector3 cam_offset;

	void Start () {
		if (cam_offset == null) {
			cam_offset = new Vector3 (0f, 7f, -3f);
		}
	}
	
	void LateUpdate () {
		transform.position = ball.transform.position + cam_offset;
	}
}
