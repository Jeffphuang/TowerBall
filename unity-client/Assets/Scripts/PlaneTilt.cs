using UnityEngine;
using System.Collections;

public class PlaneTilt : MonoBehaviour {

	//private Plane surface;
	public float tilt_speed = 10f;


	void Start () {
		//surface = GetComponent<Plane> ();
	}

	void Update () {
		float tilt_Z = Input.GetAxis ("Horizontal");
		float tilt_X = Input.GetAxis ("Vertical");
		Vector3 tilt_angles = new Vector3 (tilt_X, 0, tilt_Z);
		Debug.Log (tilt_angles);
		tilt_angles.Normalize();
		transform.Rotate(tilt_angles * tilt_speed * Time.deltaTime);
	}


}
