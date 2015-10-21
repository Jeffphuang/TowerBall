using UnityEngine;
using System.Collections;

public class KeepAwake : MonoBehaviour {

	void Awake () {
		Screen.sleepTimeout = (int)SleepTimeout.NeverSleep;
	}

}
