using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {
	
	private Rigidbody ball;
	private Vector3 next_wind;
	private float max_wind;
	private Vector3 zero = new Vector3 (0f, 0f, 0f);

	public Vector3 wind;
	public float user_speed;	


	void Start () {
		ball = GetComponent<Rigidbody> ();
		if (user_speed == null) {
			user_speed = 1f;
		}
		max_wind = user_speed - 1.5f;
		next_wind = zero;
		InvokeRepeating ("ChangeWind", 1.0f, 3.0f);
	}


	void ChangeWind() {
		float new_x = Random.Range (0f, 100f) - 50f;
		float new_z = Random.Range (0f, 100f) - 50f;
		next_wind = new Vector3 (new_x, 0f, new_z);
		next_wind.Normalize ();
		next_wind = next_wind * Random.Range (0f, max_wind);
	}
	

	public void StopWind() {
		CancelInvoke ("ChangeWind");
		wind = zero;
		next_wind = zero;
	}

	void Update() {
		wind = Vector3.Lerp (wind, next_wind, Time.deltaTime);
	}

	void FixedUpdate() {
		float x = Input.GetAxis ("Horizontal");
		float z = Input.GetAxis ("Vertical");

		Vector3 user_force = new Vector3(x, 0, z);
		user_force.Normalize ();

		ball.AddForce (user_force * user_speed + wind);
	}
}
