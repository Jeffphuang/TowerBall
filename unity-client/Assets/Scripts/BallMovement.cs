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
		max_wind = user_speed - 0.5f;
		time = 0;
		InvokeRepeating ("Timer", 1.0f, 1.0f);
	}

	void Timer() {
		time = time + 1;
	}

	float NewWindSpeed () {
		return (user_speed - 0.5f) * (1.0f - Mathf.Exp (-0.2f * time));
	}

	Vector3 NewWind () {

		int polarity1 = (int)(Random.Range (0f, 2f) - 1f);
		int polarity2 = (int)(Random.Range (0f, 2f) - 1f);

		float deviation_allowed = (1.0f - Mathf.Exp (-0.35f * time));
		return new Vector3 (polarity1 * Random.Range (0f, wind.x) + wind.x, polarity2 * Random.Range (0f, wind.y) + wind.y);
	}

	void ChangeWind () {

	}

	void FixedUpdate() {
		float x = Input.GetAxis ("Horizontal");
		float z = Input.GetAxis ("Vertical");

		Vector3 user_force = new Vector3(x, 0, z);
		user_force.Normalize ();

		ball.AddForce (user_force * user_speed + wind);
	}
}
