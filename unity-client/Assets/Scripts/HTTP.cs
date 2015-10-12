using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using SimpleJSON;

public class HTTP : MonoBehaviour {
	public static string server = "http://159.203.4.4:3000/api";
	public static string identifier;

	void Awake(){
		identifier = SystemInfo.deviceUniqueIdentifier;
	}
	IEnumerator getScore(string user){
		WWW www = new WWW (server + "/scores/?id=" + user);
		yield return www;
		JSONNode N = new JSONNode ();
		N = JSON.Parse (www.text);
		string highScore = (string) N["result"][0]["scores"][0]["score"];
		Debug.Log (www.text);
	}
	IEnumerator postScore(string user, float score){
		string postData = "{\"user\":\""+user+"\",\"score\":"+score+"}";
		Debug.Log (postData);
		Dictionary<string, string> headers = new Dictionary<string, string>();
		headers.Add("Content-Type", "application/json");
		byte[] data = Encoding.ASCII.GetBytes(postData.ToCharArray());
		WWW www = new WWW (server + "/scores", data, headers);
		yield return www;
		Debug.Log (www.text);
	}
	IEnumerator createUser(string user){
		string postData = "{\"user\":\""+user+"\"}";
		Debug.Log (postData);
		Dictionary<string, string> headers = new Dictionary<string, string>();
		headers.Add("Content-Type", "application/json");
		byte[] data = Encoding.ASCII.GetBytes(postData.ToCharArray());
		WWW www = new WWW (server + "/create", data, headers);
		
		yield return www;
		
		Debug.Log (www.text);
	}
}
