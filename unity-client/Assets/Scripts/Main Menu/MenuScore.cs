using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UI;
using SimpleJSON;

public class MenuScore : MonoBehaviour {

	public Text score;
	// Use this for initialization
	void Start () {
		StartCoroutine (getScore(HTTP.identifier));
		Debug.Log (HTTP.identifier);
	}
	
	IEnumerator getScore(string user){
		WWW www = new WWW (HTTP.server + "/scores/?id=" + user);
		yield return www;
		JSONNode N = new JSONNode ();
		N = JSON.Parse (www.text);
		if (N ["result"] [0] != null) {
			string highScore = (string)N ["result"] [0] ["scores"] [0] ["score"];
			if (highScore == null && score != null) {
				score.text = "Not Yet Played!";
			} else if (score != null) {
				score.text = highScore;
			}
		}
		else if(score.text != null){
			score.text = "Not Yet Played!";
			StartCoroutine (createUser (HTTP.identifier));
		}
	}

	IEnumerator createUser(string user){
		string postData = "{\"user\":\""+user+"\"}";
		Debug.Log (postData);
		Dictionary<string, string> headers = new Dictionary<string, string>();
		headers.Add("Content-Type", "application/json");
		byte[] data = Encoding.ASCII.GetBytes(postData.ToCharArray());
		WWW www = new WWW (HTTP.server + "/create", data, headers);
		
		yield return www;
		
		Debug.Log (www.text);
		Debug.Log ("created user");
	}
}
