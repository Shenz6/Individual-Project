using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadNextLevel : MonoBehaviour {

    public string levelName;
	private float timer;
	private Scene scene;
	private string sceneName;

	// Use this for initialization
	void Start () {
		scene = SceneManager.GetActiveScene ();
		sceneName = scene.name;
		timer = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		Debug.Log(PlayerPrefs.GetFloat("Testplane"));
	}

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") {
			PlayerPrefs.SetFloat (sceneName, timer);
            Application.LoadLevel(levelName);
        }
    
    }

}
