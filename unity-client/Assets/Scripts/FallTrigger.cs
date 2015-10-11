using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FallTrigger : MonoBehaviour {

	public Rigidbody ball;
	public BallMovement ball_control;
	public Text gameover;
	public Text score;
	public Button restart;


	void OnTriggerEnter (Collider coll) {
		ball.isKinematic = true;
		ball.detectCollisions = false;
		ball_control.StopWind ();
		gameover.text = "Game Over";
		score.text = "Score: " + ((int)Time.timeSinceLevelLoad).ToString();
		restart.

	}
}
