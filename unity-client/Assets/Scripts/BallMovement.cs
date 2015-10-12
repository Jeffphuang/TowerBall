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
		if (user_speed == 0f) {
			user_speed = 20f;
		}
		max_wind = user_speed * 1.5f;
		next_wind = zero;
		InvokeRepeating ("ChangeWind", 1.0f, 3.0f);

		InvokeRepeating ("IncreaseForce", 10.0f, 1.0f);
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

	void IncreaseForce(){
		user_speed += 0.2f;
		max_wind = user_speed * 1.5f;

	}
	void Update() {
		wind = Vector3.Lerp (wind, next_wind, Time.deltaTime);
	}

	void FixedUpdate() {
		Vector3 user_force = new Vector3(0f,0f,0f);
		Vector3 accel = Input.acceleration;
		Debug.Log ("x");
		Debug.Log (accel.x);
		Debug.Log ("y");
		Debug.Log(accel.y);
		Debug.Log ("z");
		Debug.Log (accel.z);
		user_force = new Vector3(accel.x , 0f, accel.y) * 2f;
		Debug.Log (user_force);
		ball.AddForce (user_force * user_speed + wind);
	}
}
