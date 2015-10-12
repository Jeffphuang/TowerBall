using UnityEngine;
using System.Collections;

public class UIButton : MonoBehaviour {
	
	public Transition change;
	public void ChangeLevel(){
		StartCoroutine (Transition());
	}
	IEnumerator Transition(){
		float fadeTime = change.BeginFade (1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel (Application.loadedLevel + 1);
	}
}
