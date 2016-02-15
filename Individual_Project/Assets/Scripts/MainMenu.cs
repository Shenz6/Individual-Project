using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public string levelName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NewGame() {
        Application.LoadLevel(levelName);
    }

    public void ContinueGame() { 
		Application.LoadLevel (PlayerPrefs.GetInt ("save"));
    }

    public void ExitGame() {
        Application.Quit();
    }

}
