using UnityEngine;
using System.Collections;

public class SphereRotate : MonoBehaviour {

	public float speed = 1;
	private float z = 30;
	private float y = 30;
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0f, y * speed, z * speed) * Time.deltaTime);
	}
}
