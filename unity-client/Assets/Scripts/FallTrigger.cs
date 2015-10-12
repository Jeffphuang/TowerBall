using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text;
using SimpleJSON;

public class FallTrigger : MonoBehaviour {

	public Rigidbody ball;
	public BallMovement ball_control;
	public Text gameover;
	public Text score;
	public Button restart;
	public Text restart_text;
	public Text best_score;

	private bool gameOver;
	private float final_score;

	void Start () {
		restart.enabled = false;
		gameOver = false;
	}

	void Update() {
		if (!(gameOver)) {
			best_score.text = "Your Score: " + Time.timeSinceLevelLoad.ToString("#.##");
		}
	}

	IEnumerator postScore(string user, string score){
		string postData = "{\"user\":\"" + user + "\",\"score\":" + score + "}";
		Dictionary<string, string> headers = new Dictionary<string, string> ();
		headers.Add ("Content-Type", "application/json");
		byte[] data = Encoding.ASCII.GetBytes (postData.ToCharArray ());
		WWW www = new WWW (HTTP.server + "/scores", data, headers);
		yield return www;
	}

	IEnumerator getScore(string user){
		WWW www = new WWW (HTTP.server + "/scores/?id=" + user);
		yield return www;
		JSONNode N = new JSONNode ();
		N = JSON.Parse (www.text);
		try {
			if (N ["success"].ToString() == "\"true\"") {
				if (N ["result"] [0] != null) {
					string highScore = (string)N ["result"] [0] ["scores"] [0] ["score"];
					float highScore_val = float.Parse (highScore);
					if (highScore == null && score != null) {
						best_score.text = "Best score: " + Time.timeSinceLevelLoad.ToString ("#.##");
					} else if (score != null) {
						if (highScore_val >= final_score) {
							best_score.text = "Best score: " + highScore;
						} else {
							best_score.text = "Best score: " + final_score.ToString ("#.##");
						}
					}
				} else if (best_score.text != null) {
					best_score.text = final_score.ToString ("#.##");
					StartCoroutine (createUser (HTTP.identifier));
				}
			}
		} catch {
			best_score.text = " ";
		}
	}
	
	IEnumerator createUser(string user){
		string postData = "{\"user\":\""+user+"\"}";
		Dictionary<string, string> headers = new Dictionary<string, string>();
		headers.Add("Content-Type", "application/json");
		byte[] data = Encoding.ASCII.GetBytes(postData.ToCharArray());
		WWW www = new WWW (HTTP.server + "/create", data, headers);
		
		yield return www;
	}

	void OnTriggerEnter (Collider coll) {
		gameOver = true;
		ball.isKinematic = true;
		ball.detectCollisions = false;
		ball_control.StopWind ();
		gameover.text = "Game Over";
		final_score = Time.timeSinceLevelLoad;
		string score_val = final_score.ToString("#.##");
		score.text = "Score: " + score_val;
		restart.enabled = true;
		restart_text.text = "Play\nAgain";
		restart.GetComponent<Image>().color = new Vector4 (255f, 255f, 255f, 255f);
		StartCoroutine (postScore (HTTP.identifier, score_val));
		StartCoroutine (getScore (HTTP.identifier));
	}
}
