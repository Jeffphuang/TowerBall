using UnityEngine;
using System.Collections;

public class TestGyro : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (Input.gyro.attitude);
	}
}
