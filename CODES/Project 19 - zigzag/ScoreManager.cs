using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;
	public int score;
	public int highScore;

	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		score = 0;
		PlayerPrefs.SetInt ("score", score);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void incrementScore(){
		score += 1;
	}

	public void startScore(){
		InvokeRepeating ("incrementScore", 0.1f, 0.5f);
	}

	public void StopScore(){
		
		CancelInvoke ("incrementScore");


		PlayerPrefs.SetInt ("score", score);

		if (PlayerPrefs.HasKey ("highScore")) {
			if (score > PlayerPrefs.GetInt ("highScore")) {
				PlayerPrefs.SetInt ("highScore", score);
			}
		} 
		else {
			PlayerPrefs.SetInt ("highScore", score);
		}
	}
}
