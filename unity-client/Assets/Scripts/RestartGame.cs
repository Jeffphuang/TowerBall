using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour {

	public void Reset() {
		Application.LoadLevel ("Table");
	}
}
