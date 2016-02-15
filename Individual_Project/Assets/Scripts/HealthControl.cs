using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthControl : MonoBehaviour {

    public Image healthBar;
    public float health;
    public GameObject restartDialog;
    private float hitCoolDown;
    private bool beenHit;

	// Use this for initialization
	void Start () {
        ShowRestartDialog(false);
        hitCoolDown = 180.0f;
	}
	
	// Update is called once per frame
	void Update () {
        CheckHealth();

        if (hitCoolDown > 0.0f)
        {
            hitCoolDown--;
        }
        else
        {
            beenHit = false;
        }
	}

    void OnTriggerEnter(Collider col) {
        if (col.GetComponent<Collider>().CompareTag("EnemyHit") && beenHit == false)
        {
            SubtractHealth(20.0f);
            beenHit = true;
            hitCoolDown = 180.0f;
        }
        //if life restore added edit here!!!!
        /*
        else if (col.Collder.CompareTag(""))
        { 
        }
        */
    }

    void CheckHealth() {
        healthBar.rectTransform.localScale = new Vector3(health / 100, healthBar.rectTransform.localScale.y, healthBar.rectTransform.localScale.z);

        if (health <= 0.0f)
        {
            ShowRestartDialog(true);
        }
    }

    public void SubtractHealth(float amount) {
        if (health - amount < 0.0f)
        {
            health = 0.0f;
        }
        else
        {
            health -= amount;
        }
    }

    public void AddHealth(float amount) {
        if (health + amount > 100.0f)
        {
            health = 100.0f;
        }
        else
        {
            health += amount;
        }
    }

    public void ShowRestartDialog(bool c) {
        if (c == true)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
        restartDialog.SetActive(c);
    }

    public void Restart() {
        Application.LoadLevel(Application.loadedLevel);
        //to ensure the lighting does not 'brake' during reload go to window > lighting > lightmaps, and manually bake the lightmap.
    }

    public void QuitGame() {
        Application.Quit();
    }
}
