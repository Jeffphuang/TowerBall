using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIupdater : MonoBehaviour {
	
	public BallMovement ball;

	private Vector3 offset = new Vector3(0f, -1f, -3f);
	
	void Update () {
		float x = ball.wind.x;
		float y = ball.wind.y;

		float angle = Vector3.Angle (offset, ball.wind);

		transform.eulerAngles = new Vector3 (0f, 0f, angle);
	}
}
