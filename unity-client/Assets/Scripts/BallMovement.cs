using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {
	
	private Rigidbody ball;
	public float user_speed = 1f;
	public int time;
	public Vector3 wind;
	private float max_wind;

	void Start () {
		ball = GetComponent<Rigidbody> ();
		max_wind = user_speed - 1.5f;
		time = 0;
		InvokeRepeating ("Timer", 1.0f, 1.0f);
		InvokeRepeating ("ChangeWind", 1.0f, 3.0f);
	}

	void Timer() {
		time = time + 1;
	}
	

	void ChangeWind() {
		float new_x = Random.Range (0f, 100f) - 50f;
		float new_z = Random.Range (0f, 100f) - 50f;
		Vector3 next_wind = new Vector3 (new_x, 0f, new_z);
		next_wind.Normalize ();
		next_wind = next_wind * Random.Range (0f, max_wind);
		wind = Vector3.Lerp (wind, next_wind, 3.0f);
	}

	void FixedUpdate() {
		float x = Input.GetAxis ("Horizontal");
		float z = Input.GetAxis ("Vertical");

		Vector3 user_force = new Vector3(x, 0, z);
		user_force.Normalize ();

		ball.AddForce (user_force * user_speed + wind);
	}
}
