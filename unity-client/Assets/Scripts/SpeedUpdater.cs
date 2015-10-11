using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpeedUpdater : MonoBehaviour {

	public BallMovement ball;
	private string units;
	public Text indicator;

	void Start () {
		units = "m/s";
		indicator = GetComponent<Text> ();
	}	
	
	void Update () {
		float speed = ball.wind.magnitude;
		indicator.text = speed.ToString () + units;
	}
}
