using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ArrowUpdater : MonoBehaviour {
	
	public BallMovement ball;

	private Vector3 offset = new Vector3(0f, 0f, 90f);
	
	void Update () {
		float x = ball.wind.x;
		float z = ball.wind.z;

		float angle = Vector2.Angle (new Vector2(1f, 0f), new Vector2(Mathf.Abs(x), Mathf.Abs(z)));

		if (x < 0 && z < 0) {
			angle = 180 + angle;
		} else if (x < 0) {
			angle = 180 - angle;
		} else if (z < 0) {
			angle = 360 - angle;
		}

		transform.eulerAngles = (new Vector3 (0f, 0f, angle) + offset);
	}
}
