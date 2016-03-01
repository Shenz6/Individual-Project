using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class HighScoreDisplay : MonoBehaviour {

	public string levelName;
	public string ppSlot;
	private float highTime;
	private float newTime;
	private string displayTime;
	private Text display;
	private Scene scene;

	// Use this for initialization
	void Start () {
		display = GetComponent <UnityEngine.UI.Text>();
		highTime = PlayerPrefs.GetFloat (ppSlot);
		newTime = PlayerPrefs.GetFloat (levelName);
		scene = SceneManager.GetActiveScene ();

		if (newTime < highTime) {
			PlayerPrefs.SetFloat (ppSlot, newTime);

			highTime = newTime;
		}
		else if (highTime == 0) {
			PlayerPrefs.SetFloat (ppSlot, newTime);

			highTime = newTime;
		}
	}
	
	// Update is called once per frame
	void Update () {

		displayTime = string.Format("{0:#0}:{1:00}.{2:0}",
			Mathf.Floor(highTime / 60),//minutes
			Mathf.Floor(highTime) % 60,//seconds
			Mathf.Floor((highTime*10) % 10));//miliseconds
	
		display.text = displayTime;

		//display.text = "hi";

		Debug.Log (PlayerPrefs.GetFloat (levelName));
		Debug.Log (scene.name);
	}
}
