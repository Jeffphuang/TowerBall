using UnityEngine;
using System.Collections;
using System.Threading;

//this script used for test purpose ,it do by default 1000 logs  + 1000 warnings + 1000 errors
//so you can check the functionality of in game logs
//just drop this scrip to any empty game object on first scene your game start at
public class TestReporter : MonoBehaviour {
	
	void Update(){
		Debug.Log ("Game Updated");
	}
}
