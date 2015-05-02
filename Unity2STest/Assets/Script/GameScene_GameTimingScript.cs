using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameScene_GameTimingScript : MonoBehaviour {

	float timer  = 45f;
	bool started = false;
	int CurrentScore = 0;
	Text TimerText;
	Text ScoreText;

	public GameObject TextController;
	public GameObject ScoreTextControl;


	// Use this for initialization
	void Start () {
		StartTimer ();

		TimerText = TextController.GetComponent<Text> ();
		ScoreText = ScoreTextControl.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update()
	{ 
		if (started) {

			timer -= Time.deltaTime; 

			if (timer > 0) {
				TimerText.text = timer.ToString ("00.0");
			} else {
				TimerText.text = "TIME OVER"; 
				timer = 0;

				/*
				if (Input.GetKeyDown ("x")) { // reload the same level Application.LoadLevel(Application.loadedLevel);
						timer = 45f;
				} */
			}
		}
	}

	public void StartTimer ()
	{
		started = true;
	}
}
