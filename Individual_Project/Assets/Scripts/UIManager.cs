using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    public GameObject pausePanel;
    public GameObject joysticks;

    public bool isPaused;

	// Use this for initialization
	void Start () {
        isPaused = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (isPaused == true)
        {
            PauseGame(true);
        }
        else 
        {
            PauseGame(false);
        }

        //allow user to pause using back button on android
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchPause();
        }

        /*
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SwitchPause();
                
                //return;
            }
        }
         */
        /*
        if (input.GetButtonDown("Cancel"))
        {
            SwitchPause();
        }
	*/
	}

    void PauseGame(bool state) {
        if (state == true)
        {
            Time.timeScale = 0.0f; //this makes the game paused
            //joysticks.SetActive(false); // hide the control sticks

        }
        else
        {
            Time.timeScale = 1.0f; // this unpauses the game
            //joysticks.SetActive(true); // show the control sticks

        }

        pausePanel.SetActive(state);
    }

    public void SwitchPause() {
        if (isPaused == true)
        {
            isPaused = false;
        }
        else
        {
            isPaused = true;
        }
    }

	public void Save() {
		PlayerPrefs.SetInt ("save", Application.loadedLevel);
	}

	public void Load() {
		Application.LoadLevel (PlayerPrefs.GetInt ("save"));
	}

	public void Quit() {
		Application.LoadLevel ("MainMenu");
	}

}
