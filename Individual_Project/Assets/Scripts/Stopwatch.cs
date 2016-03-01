using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Stopwatch : MonoBehaviour {

	public static float timer;
	private string watch;
	private Text timeDisplay;

	// Use this for initialization
	void Start () {
		timeDisplay = GetComponent <UnityEngine.UI.Text>();
		timer = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;


		watch = string.Format("{0:#0}:{1:00}.{2:0}",
			Mathf.Floor(timer / 60),//minutes
			Mathf.Floor(timer) % 60,//seconds
			Mathf.Floor((timer*10) % 10));//miliseconds

		timeDisplay.text = watch;
	}
}
